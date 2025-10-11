using System.Threading;
using System.Threading.Tasks;

namespace Models.Application.Handlers.Base;

/// <summary>
///     Base class for all requests that need to be processed by a business handler.
/// </summary>
public abstract class HandlerRequest
{
    /// <summary>
    ///     Processes the request and executes the associated business logic.
    /// </summary>
    /// <param name="ct">
    ///     Allow to cancel the operation when need.
    /// </param>
    /// <returns>
    ///     Return a Task object with corresponded HandlerResponse object
    ///     which contains the result of the operation (success, data, or error).
    /// </returns>
    public abstract Task<HandlerResponse> HandleAsync(CancellationToken ct);

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
    public abstract HandlerResponse GetResponse(HandlerResponse response);
}