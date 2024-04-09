using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moviefactory.Domain.Movies;

namespace Moviefactory.Presentation.Endpoints;

public static class MovieEndpoints
{
    public static WebApplication Add(WebApplication app)
    {
        var group = app.MapGroup("/movies")
            .WithOpenApi();

        group.MapGet("/", GetMovies)
            .WithDescription("Get specified number of movies.")
            .WithName("GetMovies");

        group.MapGet("/{title}", GetMovieByTitle)
            .WithDescription("Get movie by title.")
            .WithName("GetMovieByTitle");

        return app;
    }

    private static async Task<Ok<List<Movie>>> GetMovies(IMovieRepository movieRepository, [FromQuery(Name = "count")] int count)
    {
        var movies = await movieRepository.GetMovies(count);
        return TypedResults.Ok(movies);
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