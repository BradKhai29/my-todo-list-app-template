using System.Threading;
using System.Threading.Tasks;
using Models.Application.Handlers.Base.Registry;

namespace Models.Application.Handlers.Base;

/// <summary>
///     Base class for a request that expects a specific type of response.
/// </summary>
/// <remarks>
///     Use this class for all your specific requests (Ex: UserLoginRequest),
///     specifying the exact type of expected response (Ex: UserLoginResponse).
/// </remarks>
/// <typeparam name="TResponse">
///     The specific type of HandlerResponse this request is expected to return.
///     (Ex: UserLoginResponse) instead of just the generic <b>HandlerResponse</b>.
/// </typeparam>
public abstract class HandlerRequest<TResponse> : HandlerRequest
    where TResponse : HandlerResponse
{
    public override Task<HandlerResponse> HandleAsync(CancellationToken ct)
    {
        // Resolve the request with handler registry.
        return HandlerRequestRegistry.Instance.ResolveAsync(this, ct);
    }

    public override TResponse GetResponse(HandlerResponse response)
    {
        return response as TResponse;
    }
}
