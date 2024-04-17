using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Moviefactory.Domain.Movies;

namespace Moviefactory.Presentation.Endpoints.Movies;

public sealed class GetMovieByTitleEndpoint : IEndpoint<MovieEndpointGroup>
{
    public void RegisterEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/{title}", GetMovieByTitle)
            .WithDescription("Get movie by title.")
            .WithName("GetMovieByTitle");
    }

    private static async Task<Results<Ok<Movie>, NotFound>> GetMovieByTitle(IMovieRepository movieRepository, string title)
    {
        var movie = await movieRepository.GetMovieByTitle(title);

        if (movie is null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(movie);
    }
}