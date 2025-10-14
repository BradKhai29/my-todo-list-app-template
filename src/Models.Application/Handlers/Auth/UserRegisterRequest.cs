using Models.Application.Handlers.Base;

namespace Models.Application.Handlers.Auth;

public class UserRegisterRequest : HandlerRequest<UserRegisterResponse>
{
    public string Email { get; set; }

    public string Password { get; set; }
}