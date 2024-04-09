using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Moviefactory.Domain.Movies;

namespace Moviefactory.Persistence.ClassMaps;

//Use SourceGenerator to call them
public static class MovieClassMap
{
    public static void Register()
    {
        BsonClassMap.RegisterClassMap<Movie>(cm =>
        {
            cm.MapIdMember(m => m.Id)
                .SetElementName("_id")
                .SetOrder(1)
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.ObjectId));

            cm.MapMember(m => m.ShowId)
                .SetElementName("show_id")
                .SetOrder(2);

            cm.MapMember(m => m.Type)
                .SetElementName("type")
                .SetOrder(3);

            cm.MapMember(m => m.Title)
                .SetElementName("title")
                .SetOrder(4);

            cm.MapMember(m => m.Director)
                .SetElementName("director")
                .SetOrder(5);

            cm.MapMember(m => m.Country)
                .SetElementName("country")
                .SetOrder(6);

            cm.MapMember(m => m.DateAdded)
                .SetElementName("date_added")
                .SetOrder(7);

            cm.MapMember(m => m.ReleaseYear)
                .SetElementName("release_year")
                .SetOrder(8);

            cm.MapMember(m => m.Rating)
                .SetElementName("rating")
                .SetOrder(9);

            cm.MapMember(m => m.Duration)
                .SetElementName("duration")
                .SetOrder(10);

            cm.MapMember(m => m.ListedIn)
                .SetElementName("listed_in")
                .SetOrder(11);

            cm.MapMember(m => m.Description)
                .SetElementName("description")
                .SetOrder(12);

            cm.MapMember(m => m.Cast)
                .SetElementName("cast")
                .SetOrder(13);
        });
    }
}