using Models.Api.Web.Base;

namespace Models.Api.Web.Users.Auth;

public class UserRegisterResponseDto : ApiResponseDto
{
    public bool IsSuccess { get; set; }
}