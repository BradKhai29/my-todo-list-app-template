using Models.Application.Handlers.Base;

namespace Application.Handlers.Interface;

public interface IBusinessHandler
{
    Task<HandlerResponse> HandleAsync(HandlerRequest request);
}