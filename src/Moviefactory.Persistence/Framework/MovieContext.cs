using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moviefactory.Domain.Movies;
using Moviefactory.Infrastructure.Options;
using Moviefactory.Persistence.ClassMaps;

namespace Moviefactory.Persistence.Framework;

public class MovieContext : IMovieContext
{
    static MovieContext()
    {
        MovieClassMap.Register();
    }

    public MovieContext(IServiceProvider serviceProvider)
    {
        var databaseOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

        var client = new MongoClient(databaseOptions.ConnectionString);
        var database = client.GetDatabase(databaseOptions.DatabaseName);
        Movies = database.GetCollection<Movie>(databaseOptions.CollectionName);
    }

    public IMongoCollection<Movie> Movies { get; }
}