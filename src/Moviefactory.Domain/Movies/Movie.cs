namespace Moviefactory.Domain.Movies;

public sealed class Movie
(
    string id, 
    string showId, 
    string type, 
    string title, 
    string director, 
    string country, 
    string dateAdded, 
    int releaseYear, 
    string rating, 
    string duration, 
    string listedIn, 
    string description, 
    string cast
)
{
    public string Id { get; set; } = id;
    public string ShowId { get; set; } = showId;
    public string Type { get; set; } = type;
    public string Title { get; set; } = title;
    public string? Director { get; set; } = director;
    public string Country { get; set; } = country;
    public string DateAdded { get; set; } = dateAdded;
    public int ReleaseYear { get; set; } = releaseYear;
    public string Rating { get; set; } = rating;
    public string Duration { get; set; } = duration;
    public string ListedIn { get; set; } = listedIn;
    public string Description { get; set; } = description;
    public string Cast { get; set; } = cast;
}