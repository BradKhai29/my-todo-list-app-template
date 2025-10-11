using System.Collections.Concurrent;
using Application.Handlers.Interface;
using Microsoft.Extensions.DependencyInjection;
using Models.Application.Handlers.Base;
using Models.Application.Handlers.Base.Registry;

namespace Application.Handlers.Base;

public sealed class AppHandlerRequestRegistry : HandlerRequestRegistry
{
    private static readonly object _lock = new();
    private static bool _isSetUp = false;
    private static IServiceProvider _serviceProvider;
    private static readonly ConcurrentDictionary<Type, ObjectFactory> _factoryCache = new();


    private AppHandlerRequestRegistry()
    {
    }

    public override Task<HandlerResponse> ResolveAsync<TRequest>(
        TRequest request, CancellationToken ct = default)
    {
        var tRequest = typeof(TRequest);
        var requestTypeName = tRequest.Name;

        // Try to get the feature handler definition from the container.
        _requestRegistry.TryGetValue(requestTypeName, out var handlerDefinition);

        // Check if the handler definition is not null.
        if (Equals(handlerDefinition, default))
        {
            return Task.FromResult<HandlerResponse>(default);
        }

        System.Console.WriteLine(request);

        // Initialize target handler.
        var handler = CreateInstance(handlerDefinition);
        try
        {
            var handler2 = (IBusinessHandler)handler;
            // Execute the handler.
            if (handler2 == null)
            {
                System.Console.WriteLine("Why null???");
                return default;
            }
            else
            {
                return handler2.HandleAsync(request);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex);
            return null;
        }

    }

    internal static object CreateInstance(Type type)
    {
        // Get the factory from the cache.
        var factory = _factoryCache.GetOrAdd(type, FactoryInitializer);

        // Create an scope service provider.
        var scopeServiceProvider = _serviceProvider.CreateScope().ServiceProvider;

        // Execute the factory.
        return factory(scopeServiceProvider, null);

        // Initialize the factory.
        static ObjectFactory FactoryInitializer(Type t)
        {
            return ActivatorUtilities.CreateFactory(t, Type.EmptyTypes);
        }
    }

    public static void SetUp(IServiceProvider serviceProvider)
    {
        if (_isSetUp)
        {
            return;
        }

        lock (_lock)
        {
            if (!_isSetUp)
            {
                _serviceProvider = serviceProvider;
                var registry = new AppHandlerRequestRegistry();
                registry.Setup();
            }
        }
    }

    protected override void Setup()
    {
        var handlerAssembly = typeof(BusinessHandler<,>).Assembly;
        var assemblyTypes = handlerAssembly.GetTypes();

        foreach (var handlerType in assemblyTypes)
        {
            if (IsBusinessHandlerType(handlerType))
            {
                var requestType = handlerType.GetHandlerRequestType();
                _requestRegistry.TryAdd(requestType.Name, handlerType);
            }
        }

        _isSetUp = true;
        _instance = this;
    }

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
}
