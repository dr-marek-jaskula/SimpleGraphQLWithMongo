using MongoDB.Driver;
using Moviefactory.Domain.Movies;
using Moviefactory.Persistence.Framework;

namespace Moviefactory.Persistence.Repositories;

public sealed class MovieRepository(IMovieContext movieContext) : IMovieRepository
{
    private readonly IMovieContext _movieContext = movieContext;

    public async Task<Movie?> GetMovieByTitle(string title)
    {
        FilterDefinition<Movie> filter = Builders<Movie>.Filter.Eq(p => p.Title, title);

        return await _movieContext
            .Movies
            .Find(filter)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Movie>> GetMovies(int count)
    {
        return await _movieContext
            .Movies
            .Find(p => true)
            .Limit(count)
            .ToListAsync();
    }
}