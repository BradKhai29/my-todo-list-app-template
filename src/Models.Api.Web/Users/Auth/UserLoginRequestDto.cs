using System.Net;
using Models.Api.Web.Base;
using Models.Application.Handlers.Auth;
using Models.Application.Handlers.Base;

namespace Models.Api.Web.Users.Auth;

public class UserLoginRequestDto : ApiRequestDto<UserLoginRequest, UserLoginResponseDto>
{
    public string Email { get; set; }

    public string Password { get; set; }

    public bool RememberLogin { get; set; }

    public override UserLoginRequest GetRequest()
    {
        return new UserLoginRequest
        {
            LoginInfo = new()
            {
                Email = Email,
                Password = Password,
                RememberLogin = RememberLogin
            }
        };
    }

    public override UserLoginResponseDto GetResponseDto(HandlerResponse handlerResponse)
    {
        var response = UserLoginRequest.GetExactResponse(handlerResponse);

        return new UserLoginResponseDto
        {
            AppCode = response.AppCode.Code,
            HttpStatusCode = (int)response.AppCode.HttpStatusCode,
            AccessToken = response.LoginResponse.AccessToken,
            RefreshToken = response.LoginResponse.RefreshToken,
        };
    }

}