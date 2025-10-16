using Models.Application.Services.Base;

namespace Models.Application.Services.Auth;

public sealed class LoginModel : IServiceModel
{
    public string Email { get; set; }

    public string Password { get; set; }

    public bool RememberLogin { get; set; }
}
