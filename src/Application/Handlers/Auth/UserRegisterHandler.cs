using System.Threading.Tasks;
using Application.Handlers.Common;
using Application.Handlers.Interface;
using Models.Application.Handlers.Auth;

namespace Application.Handlers.Auth;

[HandlerDefinition(RequestType = typeof(UserRegisterRequest), ResponseType = typeof(UserRegisterResponse))]
public class UserRegisterHandler : BusinessHandler<UserRegisterRequest, UserRegisterResponse>
{
    protected override Task<UserRegisterResponse> HandleAsync(UserRegisterRequest request)
    {
        return Task.FromResult(new UserRegisterResponse
        {
            IsSuccess = true,
        });
    }
}