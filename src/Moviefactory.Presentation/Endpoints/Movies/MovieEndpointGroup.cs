using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Moviefactory.Presentation.Endpoints.Movies;

public class MovieEndpointGroup : IEndpointGroup
{
    public IEndpointRouteBuilder RegisterEndpointGroup(IEndpointRouteBuilder app)
    {
        return app.MapGroup("/movies")
            .WithOpenApi()
            .WithTags(Tags.Movies);
    }
}