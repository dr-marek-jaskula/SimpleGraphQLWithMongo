using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Moviefactory.Presentation.GraphQL.Queries;
using Moviefactory.Presentation.Registration;

namespace Microsoft.Extensions.DependencyInjection;

public static class PresentationLayerRegistration
{
    public static IServiceCollection RegisterPresentationLayer(this IServiceCollection services)
    {
        services
            .AddGraphQL()
            .AddGraphQLServer()
            .AddQueryType<MoviesQuery>();

        return services;
    }

    public static WebApplication AddPresentationLayer(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapGraphQL();

        return EndpointRegistration.RegisterEndpoints(app);
    }
}