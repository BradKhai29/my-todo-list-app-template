using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Application.Services.Interface.Token.Common;

namespace Application.Services.Interface.Token;

public interface IJwtTokenService<TJwtProvider>
    where TJwtProvider : JwtProvider
{
    string GetToken(List<Claim> identityClaims);

    Task<string> GetTokenAsync(List<Claim> identityClaims, CancellationToken ct = default);
}
