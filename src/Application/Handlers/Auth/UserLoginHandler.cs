using Application.Handlers.Common;
using Application.Handlers.Interface;
using Models.Application.Handlers.Auth;

namespace Application.Handlers;

[HandlerDefinition(RequestType = typeof(UserLoginRequest), ResponseType = typeof(UserLoginResponse))]
public sealed class UserLoginHandler : BusinessHandler<UserLoginRequest, UserLoginResponse>
{
    protected override async Task<UserLoginResponse> HandleAsync(UserLoginRequest request)
    {
        System.Console.WriteLine(request);

        return new UserLoginResponse()
        {
            IsSuccess = true,
            AccessToken = $"Bearer {request.Email}",
            RefreshToken = $"Bearer {request.Password}",
        };
    }
}
