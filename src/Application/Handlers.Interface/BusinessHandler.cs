using Models.Application.Handlers.Base;

namespace Application.Handlers.Interface;

public abstract class BusinessHandler<TRequest, TResponse> : IBusinessHandler
    where TRequest : HandlerRequest
    where TResponse : HandlerResponse
{
    public Task<HandlerResponse> HandleAsync(HandlerRequest request)
    {
        return HandleAsync((TRequest)request).ContinueWith<HandlerResponse>(response => response.Result);
    }

    protected abstract Task<TResponse> HandleAsync(TRequest request);
}