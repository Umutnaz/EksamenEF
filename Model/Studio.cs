namespace Model;

public class Studio //Filmselskab
{
    public string Navn { get; set; } = "";
    public List<Movie> Movies { get; set; } = new();
    public int Id { get; set; }
}