using Models.Application.Services.Base;

namespace Models.Application.Services.Auth;

public sealed class RegisterModel : IServiceModel
{
    public string Email { get; set; }

    public string Password { get; set; }
}