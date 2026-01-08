namespace Model;

// Simpel EF-model
public class Actor
{
    public int Id { get; set; }          // Primær nøgle
    public string Navn { get; set; }
    public string? Kon { get; set; } = "";   // Navn
    
    public List<Movie>? Movies { get; set; } = new(); //da en actor kan have været med i mange movies
    
}