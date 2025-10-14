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
}