using System.Security.Claims;
using Application.Services.Interface.Token;
using Application.Services.Interface.Token.Common;

namespace Infrastructure.Services.Token;

public sealed class AppJwtTokenService : IJwtTokenService<LocalJwtProvider>
{
    private const string BearerPrefix = "Bearer";

    public string GetToken(List<Claim> identityClaims)
    {
        if (identityClaims == null || identityClaims.Count == 0)
        {
            return $"{BearerPrefix} empty";
        }

        return $"{BearerPrefix} Claims[{identityClaims.Count}]";
    }

    public Task<string> GetTokenAsync(List<Claim> identityClaims, CancellationToken ct = default)
    {
        return Task.FromResult(GetToken(identityClaims));
    }

}
