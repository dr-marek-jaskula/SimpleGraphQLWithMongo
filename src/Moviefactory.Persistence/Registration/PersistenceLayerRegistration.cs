using Microsoft.Extensions.Hosting;
using Moviefactory.Domain.Movies;
using Moviefactory.Persistence.Framework;
using Moviefactory.Persistence.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class PersistenceLayerRegistration
{
    public static IServiceCollection RegisterPersistenceLayer(this IServiceCollection services, IHostEnvironment environment)
    {
        services
            .AddScoped<IMovieContext, MovieContext>()
            .AddScoped<IMovieRepository, MovieRepository>();

        return services;
    }
}