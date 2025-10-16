using Models.Application.Handlers.AppCode.Auth;
using Models.Application.Handlers.Base;
using Models.Application.Services.Auth;

namespace Models.Application.Handlers.Auth;

public class UserLoginResponse : HandlerResponse
{
    public LoginResponseModel LoginResponse { get; set; }

    public UserLoginAppCode AppCode { get; set; }

    public override string ToString()
    {
        return $"Is Success: {LoginResponse.IsSuccess}, AccessToken: {LoginResponse.AccessToken}, RefreshToken: {LoginResponse.RefreshToken}";
    }
}
