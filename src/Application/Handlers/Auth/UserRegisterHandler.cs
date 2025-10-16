using System.Threading;
using System.Threading.Tasks;
using Application.Handlers.Base.CustomAttributes;
using Application.Handlers.Base.Interfaces;
using Models.Application.Handlers.Auth;

namespace Application.Handlers.Auth;

[HandlerDefinition(RequestType = typeof(UserRegisterRequest), ResponseType = typeof(UserRegisterResponse))]
public class UserRegisterHandler : BusinessHandler<UserRegisterRequest, UserRegisterResponse>
{
    protected override Task<UserRegisterResponse> HandleAsync(UserRegisterRequest request, CancellationToken ct)
    {
        return Task.FromResult(new UserRegisterResponse
        {
            IsSuccess = true,
        });
    }
}