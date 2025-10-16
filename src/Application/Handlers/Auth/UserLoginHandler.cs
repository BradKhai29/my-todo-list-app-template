using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Handlers.Base.CustomAttributes;
using Application.Handlers.Base.Interfaces;
using Application.Services.Interface.Auth;
using Models.Application.Handlers.AppCode.Auth;
using Models.Application.Handlers.Auth;

namespace Application.Handlers;

[HandlerDefinition(RequestType = typeof(UserLoginRequest), ResponseType = typeof(UserLoginResponse))]
public sealed class UserLoginHandler : BusinessHandler<UserLoginRequest, UserLoginResponse>
{
    private readonly Lazy<IUserAuthService> _authService;

    public UserLoginHandler(Lazy<IUserAuthService> authService)
    {
        _authService = authService;
    }

    protected override async Task<UserLoginResponse> HandleAsync(UserLoginRequest request, CancellationToken ct)
    {
        var isExisted = await _authService.Value.IsEmailExistedAsync(request.LoginInfo.Email, ct);
        if (isExisted)
        {
            return new UserLoginResponse
            {
                AppCode = UserLoginAppCode.EmailExisted,
                LoginResponse = new()
                {
                    IsSuccess = false,
                    AccessToken = null,
                    RefreshToken = null,
                }
            };
        }

        var loginResponse = await _authService.Value.LoginAsync(request.LoginInfo, ct);
        return new UserLoginResponse
        {
            AppCode = UserLoginAppCode.LoginSuccess,
            LoginResponse = loginResponse,
        };
    }
}
