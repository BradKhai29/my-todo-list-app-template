using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Handlers.Base.Exceptions;
using Application.Handlers.Common;
using Application.Handlers.Interface;
using Microsoft.Extensions.DependencyInjection;
using Models.Application.Handlers.Base;
using Models.Application.Handlers.Base.Registry;

namespace Application.Handlers.Base;

/// <summary> Implementation of the HandlerRequestRegistry </summary>
public sealed class AppHandlerRequestRegistry : HandlerRequestRegistry
{
    #region Private fields
    private static IServiceProvider _rootServiceProvider;
    private static readonly ConcurrentDictionary<Type, ObjectFactory> _factoryCache = new();
    #endregion

    private AppHandlerRequestRegistry()
    {
        Setup();
    }

    public override async Task<HandlerResponse> ResolveAsync<TRequest>(TRequest request, CancellationToken ct = default)
    {
        // Try to get the feature handler definition from the container.
        var requestType = request.GetType();

        // Check if the handler definition is not null.
        if (!_requestRegistry.TryGetValue(requestType, out var handlerDefinition))
        {
            throw HandlerRequestRegistrySetupException.CannotFindHandlerForRequest(requestType);
        }

        // Initialize target handler and execute the request.
        await using var scope = _rootServiceProvider.CreateAsyncScope();
        var scopeServiceProvider = scope.ServiceProvider;

        // Get the cached factory (safe due to ConcurrentDictionary)
        var factory = _factoryCache.GetOrAdd(handlerDefinition, HandlerFactoryInitializer);

        // Create the handler instance using the scoped provider
        var handler = factory(scopeServiceProvider, null) as IBusinessHandler;

        // Await the handler execution for better performance and exception handling
        return await handler.HandleAsync(request);

        #region Support local methods
        static ObjectFactory HandlerFactoryInitializer(Type handlerType)
        {
            return ActivatorUtilities.CreateFactory(handlerType, Type.EmptyTypes);
        }
        #endregion
    }

    #region Set up section
    /// <summary>
    ///     Set up for this handler request registry with the related service
    ///     provider to support dependency injection for business handlers.
    /// </summary>
    /// <param name="serviceProvider">
    ///     Service provider instance to set up with.
    /// </param>
    public static void SetUp(IServiceProvider serviceProvider)
    {
        if (IsSetUp)
        {
            return;
        }

        _rootServiceProvider = serviceProvider;
        _ = new AppHandlerRequestRegistry();
    }

    protected override void Setup()
    {
        if (IsSetUp)
        {
            return;
        }

        // Process to get all business handlers from current assembly to set up for registry.
        var assemblyTypes = typeof(BusinessHandler<,>).Assembly.GetTypes();
        var handlerDefinitionType = typeof(HandlerDefinitionAttribute);

        foreach (var handlerType in assemblyTypes)
        {
            if (IsBusinessHandlerType(handlerType))
            {
                // Get the HandlerDefinitionAttribute from the target business handler
                // type to know its equivalent HandlerRequest.
                var customAttributes = handlerType.GetCustomAttributes(true);

                // Check if the target handlers already defined the definition attribute.
                var definitionAttribute = customAttributes.FirstOrDefault(type => type.GetType().Equals(handlerDefinitionType));
                if (definitionAttribute == null || definitionAttribute is not HandlerDefinitionAttribute handlerDefinition)
                {
                    throw HandlerRequestRegistrySetupException.HandlerDefinitionNotFound(handlerType);
                }

                // Add the request type for later resolve in registry logic.
                var requestType = handlerDefinition.RequestType;
                if (!_requestRegistry.TryAdd(requestType, handlerType))
                {
                    throw HandlerRequestRegistrySetupException.HandlerWithSameRequest(requestType);
                }
            }
        }

        // Set up this implementation and call the base set up.
        SetImplementedRegistry(this);
        base.Setup();
    }
    #endregion

    #region Private support methods
    /// <summary>
    ///     Check if the input type is correctly business handler type or not.
    /// </summary>
    private static bool IsBusinessHandlerType(Type inputType)
    {
        if (inputType.IsAbstract)
        {
            return false;
        }

        if (inputType.BaseType == null || !inputType.BaseType.IsGenericType)
        {
            return false;
        }

        return inputType.BaseType.GetGenericTypeDefinition().Equals(typeof(BusinessHandler<,>));
    }
    #endregion
}
