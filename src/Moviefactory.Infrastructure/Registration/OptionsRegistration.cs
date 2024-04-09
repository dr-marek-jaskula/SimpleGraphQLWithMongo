using Microsoft.Extensions.Options;
using Moviefactory.Infrastructure.Options;
using Moviefactory.Infrastructure.Validators;

namespace Microsoft.Extensions.DependencyInjection;

public static class OptionsRegistration
{
    internal static IServiceCollection RegisterOptions(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();
        services.AddSingleton<IValidateOptions<DatabaseOptions>, DatabaseOptionsValidator>();

        return services;
    }
}
