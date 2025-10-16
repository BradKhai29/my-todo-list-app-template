using System.Threading.Tasks;
using Models.Application.Services.Auth;

namespace Application.Services.Interface.Auth;

public interface IUserAuthService : IBaseAuthService
{
    Task<bool> RegisterAsync(RegisterModel registerInfo);
}
