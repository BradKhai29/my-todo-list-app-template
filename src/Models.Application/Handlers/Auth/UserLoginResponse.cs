using Models.Application.Handlers.Base;

namespace Models.Application.Handlers.Auth;

public class UserLoginResponse : HandlerResponse
{
    public bool IsSuccess { get; set; }

    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }
}
