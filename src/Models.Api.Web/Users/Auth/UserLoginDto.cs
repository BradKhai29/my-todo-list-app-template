using Models.Application.Handlers.Auth;

namespace Models.Api.Web.Users.Auth;

public class UserLoginDto
{
    public string Email { get; set; }

    public string Password { get; set; }

    public bool RememberLogin { get; set; }

    public UserLoginRequest ToRequest()
    {
        return new UserLoginRequest
        {
            Email = Email,
            Password = Password,
            RememberLogin = RememberLogin
        };
    }

    public UserLoginResponseDto GetResponseDto(UserLoginResponse businessResponse)
    {
        return new UserLoginResponseDto
        {
            HttpStatusCode = 200,
        };
    }
}