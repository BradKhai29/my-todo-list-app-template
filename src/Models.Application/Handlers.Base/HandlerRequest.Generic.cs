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

    /// <summary>
    ///     Casts a generic HandlerResponse object to the specific
    ///     <c>Response type</c> expected by this request.
    /// </summary>
    /// <remarks>
    ///     This method helps ensure type safety by converting
    ///     the response back to the correct concrete type,
    /// </remarks>
    /// <param name="response">The generic response object to cast.</param>
    /// <returns>
    ///     The response object that expected by this request instance.
    /// </returns>
    public static TResponse GetExactResponse(HandlerResponse response)
    {
        return response as TResponse;
    }
}
