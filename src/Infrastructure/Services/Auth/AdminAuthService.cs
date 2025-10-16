using System.Security.Claims;
using Application.Services.Interface.Auth;
using Application.Services.Interface.Token;
using Application.Services.Interface.Token.Common;
using Models.Application.Services.Auth;

namespace Infrastructure.Services.Auth;

public sealed class AdminAuthService : IAdminAuthService
{
    private readonly Lazy<IJwtTokenService<LocalJwtProvider>> _jwtTokenService;

    public AdminAuthService(Lazy<IJwtTokenService<LocalJwtProvider>> jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    public Task<bool> IsEmailExistedAsync(string email, CancellationToken ct)
    {
        return Task.FromResult(true);
    }

    public Task<LoginResponseModel> LoginAsync(LoginModel loginInfo, CancellationToken ct)
    {
        var accessTokenClaims = new List<Claim>();
        var refreshTokenClaims = new List<Claim>();

        var accessToken = _jwtTokenService.Value.GetToken(accessTokenClaims);
        var refreshToken = _jwtTokenService.Value.GetToken(refreshTokenClaims);
        var loginResponse = new LoginResponseModel
        {
            IsSuccess = true,
            AccessToken = accessToken,
            RefreshToken = refreshToken,
        };

        return Task.FromResult(loginResponse);
    }
}
