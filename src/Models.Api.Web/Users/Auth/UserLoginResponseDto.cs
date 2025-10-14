using Models.Api.Web.Base;

namespace Models.Api.Web.Users.Auth;

public class UserLoginResponseDto : ApiResponseDto
{
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }
}