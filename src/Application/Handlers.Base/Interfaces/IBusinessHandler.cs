using System.Threading;
using System.Threading.Tasks;
using Models.Application.Handlers.Base;

namespace Application.Handlers.Base.Interfaces;

/// <summary>
///     Defines the contract for all business handlers.
///     Every business handler class that processes a request must implement this interface.
/// </summary>
public interface IBusinessHandler
{
    /// <summary>
    ///     The main method for processing any request.
    ///     The handler takes a generic HandlerRequest and returns a generic HandlerResponse.
    /// </summary>
    /// <param name="request">
    ///     The request object to be processed.
    /// </param>
    /// <returns>
    ///     The handler response as the result of the business operation.
    /// </returns>
    Task<HandlerResponse> HandleAsync(HandlerRequest request, CancellationToken ct);
}