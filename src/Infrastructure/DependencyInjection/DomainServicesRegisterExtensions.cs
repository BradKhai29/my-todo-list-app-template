using Application.Services.Interface.Auth;
using Application.Services.Interface.Token;
using Application.Services.Interface.Token.Common;
using Infrastructure.DependencyInjection.Common;
using Infrastructure.Services.Auth;
using Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static class DomainServicesRegisterExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IUserAuthService, UserAuthService>();
        services.AddScoped<IAdminAuthService, AdminAuthService>();
        services.AddScoped<IJwtTokenService<LocalJwtProvider>, AppJwtTokenService>();
        services.AddScopedLazy<IUserAuthService, UserAuthService>();
        services.AddScopedLazy<IAdminAuthService, AdminAuthService>();
        services.AddScopedLazy<IJwtTokenService<LocalJwtProvider>, AppJwtTokenService>();

        return services;
    }
}