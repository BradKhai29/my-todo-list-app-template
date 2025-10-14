using Models.Application.Handlers.Base;

namespace Models.Application.Handlers.Auth;

public class UserLoginRequest : HandlerRequest<UserLoginResponse>
{
    public string Email { get; set; }

    public string Password { get; set; }

    public bool RememberLogin { get; set; }

    public override string ToString()
    {
        return $"Email: {Email}, Password: {Password}, Remember login: {RememberLogin}";
    }
}
