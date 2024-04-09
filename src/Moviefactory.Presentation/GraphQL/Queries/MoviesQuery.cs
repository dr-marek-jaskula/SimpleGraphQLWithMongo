using Moviefactory.Domain.Movies;

namespace Moviefactory.Presentation.GraphQL.Queries;

public sealed class MoviesQuery
{
    public async Task<List<Movie>> GetMoviesAsync([Service] IMovieRepository movieRepository)
    {
        var movies = await movieRepository.GetMovies(5);
        return movies;
    }
}