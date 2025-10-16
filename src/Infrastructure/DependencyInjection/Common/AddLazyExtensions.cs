using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection.Common;

public static class AddLazyExtensions
{
    public static IServiceCollection AddScopedLazy<TContract, TImplement>(this IServiceCollection services)
        where TContract : notnull
        where TImplement : class, TContract
    {
        services.AddScoped(serviceProvider => new Lazy<TContract>(serviceProvider.GetRequiredService<TContract>()));

        return services;
    }

    public static IServiceCollection AddSingletonLazy<TContract, TImplement>(this IServiceCollection services)
        where TContract : notnull
        where TImplement : class, TContract
    {
        services.AddSingleton(serviceProvider => new Lazy<TContract>(serviceProvider.GetRequiredService<TContract>()));

        return services;
    }

    public static IServiceCollection AddTransientLazy<TContract, TImplement>(this IServiceCollection services)
        where TContract : notnull
        where TImplement : class, TContract
    {
        services.AddTransient(serviceProvider => new Lazy<TContract>(serviceProvider.GetRequiredService<TContract>()));

        return services;
    }
}