using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Models.Application.Handlers.Base.Registry;

public abstract class HandlerRequestRegistry
{
    protected static HandlerRequestRegistry _instance;
    public static HandlerRequestRegistry Instance => _instance;
    protected static readonly ConcurrentDictionary<string, Type> _requestRegistry = new();

    protected HandlerRequestRegistry()
    {
    }

    protected abstract void Setup();

    public abstract Task<HandlerResponse> ResolveAsync<TRequest>(TRequest request, CancellationToken ct = default)
        where TRequest : HandlerRequest;
}
