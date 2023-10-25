namespace Data.Entities;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Url { get; set; }

    // Navigation
    public PokemonStats PokemonStats { get; set; }
}