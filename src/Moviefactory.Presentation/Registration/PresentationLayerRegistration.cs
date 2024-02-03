using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Moviefactory.Presentation.Endpoints;

namespace Microsoft.Extensions.DependencyInjection;

public static class PresentationLayerRegistration
{
    public static WebApplication AddPresentationLayer(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return MovieEndpoints.Add(app);
    }
}