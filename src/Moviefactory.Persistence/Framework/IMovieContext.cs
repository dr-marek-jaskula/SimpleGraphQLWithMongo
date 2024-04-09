using MongoDB.Driver;
using Moviefactory.Domain.Movies;

namespace Moviefactory.Persistence.Framework;

public interface IMovieContext
{
    IMongoCollection<Movie> Movies { get; }
}