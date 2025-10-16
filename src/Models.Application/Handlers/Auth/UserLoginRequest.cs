using Models.Application.Handlers.Base;
using Models.Application.Services.Auth;

namespace Models.Application.Handlers.Auth;

public class UserLoginRequest : HandlerRequest<UserLoginResponse>
{
    public LoginModel LoginInfo { get; set; }

    public override string ToString()
    {
        return $"Email: {LoginInfo.Email}, Password: {LoginInfo.Password}, Remember login: {LoginInfo.RememberLogin}";
    }
}
