using System.Threading;
using System.Threading.Tasks;
using Models.Application.Services.Auth;

namespace Application.Services.Interface.Auth;

public interface IBaseAuthService
{
    Task<bool> IsEmailExistedAsync(string email, CancellationToken ct);

    Task<LoginResponseModel> LoginAsync(LoginModel loginInfo, CancellationToken ct);
}
