namespace Models.Application.Handlers.Base;

public abstract class HandlerRequest<TResponse> : HandlerRequest
    where TResponse : HandlerResponse
{
    public TResponse GetResponse(HandlerResponse response)
    {
        return response as TResponse;
    }
}
