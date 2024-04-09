namespace Moviefactory.Domain.Movies;

public interface IMovieRepository
{
    Task<List<Movie>> GetMovies(int count);
    Task<Movie?> GetMovieByTitle(string title);
}