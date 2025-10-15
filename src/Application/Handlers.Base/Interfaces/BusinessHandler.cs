using System.Threading.Tasks;
using Models.Application.Handlers.Base;

namespace Application.Handlers.Base.Interfaces;

/// <summary>
///     Base class for all specific business handlers.
/// </summary>
/// <remarks>
///     This abstract class enforces that every handler specifies the exact
///     <typeparamref name="TRequest"/> it handles and the <typeparamref name="TResponse"/> it produces.
/// </remarks>
/// <typeparam name="TRequest">
///     The specific type of <see cref="HandlerRequest"/> this handler is designed to process.
/// </typeparam>
/// <typeparam name="TResponse">
///     The specific type of <see cref="HandlerResponse"/> this handler will return.
/// </typeparam>
public abstract class BusinessHandler<TRequest, TResponse> : IBusinessHandler
    where TRequest : HandlerRequest
    where TResponse : HandlerResponse
{
    /// <summary>
    ///     Implements the <see cref="IBusinessHandler.HandleAsync(HandlerRequest)"/> contract.
    /// </summary>
    /// <remarks>
    ///     This method safely casts the generic request object to the specific
    ///     <typeparamref name="TRequest"/> type and delegates the call to the protected
    ///     and type-safe <see cref="HandleAsync(TRequest)"/> method.
    /// </remarks>
    /// <param name="request">
    ///     The generic request object from the registry.
    /// </param>
    /// <returns>
    ///     The response wrapped back in a generic HandlerResponse Task.
    /// </returns>
    public async Task<HandlerResponse> HandleAsync(HandlerRequest request)
    {
        return await HandleAsync((TRequest)request);
    }

    /// <summary>
    ///     The method where the actual business logic is implemented.
    /// </summary>
    ///<remarks>
    ///     Concrete (non-abstract) handlers must implement this method.
    /// </remarks>
    /// <param name="request">
    ///     The request object to handle.
    /// </param>
    /// <returns>
    ///     A Task returning the specific response object <typeparamref name="TResponse"/>.
    /// </returns>
    protected abstract Task<TResponse> HandleAsync(TRequest request);
}