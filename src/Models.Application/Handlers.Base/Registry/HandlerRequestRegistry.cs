using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Models.Application.Handlers.Base.Registry;

/// <summary>
///     The central registry (or map) that knows which business handler
///     should process a specific <c><see cref="HandlerRequest"/></c> object.
/// </summary>
/// <remarks>
///     This class ensures the correct business logic is executed for every incoming request.
/// </remarks>
public abstract class HandlerRequestRegistry
{
    #region Registry fields
    // These static members implement the 'Singleton pattern', ensuring only one
    // instance of the registry exists in the entire application.

    private static bool _isSetup = false;
    private static readonly object _lock = new();
    /// <summary> The expected implementation of the HandlerRequestRegistry. </summary>
    private static HandlerRequestRegistry _instance;
    /// <summary>
    ///     A thread-safe dictionary used to map request types to their handler types.
    ///     The specific setup of this dictionary is defined in the concrete (non-abstract) registry class.
    /// </summary>
    protected readonly ConcurrentDictionary<Type, Type> _requestRegistry = new();
    #endregion

    /// <summary>
    ///     Gets the single, shared instance of the request registry.
    /// </summary>
    public static HandlerRequestRegistry Instance => _instance;

    /// <summary>
    ///     Check if this registry is already set up success or not. <br/>
    ///     If true, mean this registry is already set up successfully.
    /// </summary>
    public static bool IsSetUp => _isSetup;

    /// <summary>
    ///     Restrict the constructor to prevent unexpected initialization.
    /// </summary>
    protected HandlerRequestRegistry()
    {
    }

    /// <summary>
    ///     Defines how the request registry is built.
    /// </summary>
    /// <remarks>
    ///     The concrete implementation overrides this method must contain the logic
    ///     to register all requests and their corresponding handlers.
    /// </remarks>
    protected virtual void Setup()
    {
        // If already setup, stop the execution.
        if (_isSetup)
        {
            return;
        }

        lock (_lock)
        {
            if (!_isSetup)
            {
                _isSetup = true;
            }
        }
    }

    protected static void SetImplementedRegistry(HandlerRequestRegistry implementedRegistry)
    {
        _instance = implementedRegistry;
    }

    /// <summary>
    ///     The main method to find and execute the correct handler for the given request.
    /// </summary>
    /// <typeparam name="TRequest">
    ///     The specific type of HandlerRequest to be resolved.
    /// </typeparam>
    /// <param name="request">
    ///     The request object containing the data to be processed.
    /// </param>
    /// <param name="ct">
    ///     A CancellationToken to allow for cancellation of the operation.
    /// </param>
    /// <returns>
    ///     A Task that, when complete, returns the final HandlerResponse from the business logic.
    /// </returns>
    public abstract Task<HandlerResponse> ResolveAsync<TRequest>(TRequest request, CancellationToken ct = default)
        where TRequest : HandlerRequest;
}
