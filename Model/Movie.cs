namespace Model;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public int Year { get; set; }

    public List<Actor> Actors { get; set; } = new();
    public int StudioId { get; set; } //dette er den fk som ef bruger til at forbinde dem //derfor redundance
    
    public Studio Studio { get; set; } = null!;
}