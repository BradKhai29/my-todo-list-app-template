using Models.Application.Services.Base;

namespace Models.Application.Services.Auth;

public sealed class LoginResponseModel : IServiceModel
{
    public bool IsSuccess { get; set; }

    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }
}
