using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moviefactory.Domain.Movies;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;

namespace Moviefactory.Presentation.Endpoints.Movies;

public sealed class GetMoviesEndpoint : IEndpoint<MovieEndpointGroup>
{
    public void RegisterEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetMovies)
            .WithDescription("Get specified number of movies.")
            .WithName("GetMovies");
    }

    private static async Task<Ok<List<Movie>>> GetMovies(IMovieRepository movieRepository, [FromQuery(Name = "count")] int count)
    {
        var movies = await movieRepository.GetMovies(count);
        return TypedResults.Ok(movies);
    }
}