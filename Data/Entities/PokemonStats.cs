namespace Data.Entities;

public class PokemonStats
{
    public int Id { get; set; }

    public int Experience { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public string Description { get; set; }

    // Navigation
    public int PokemonId { get; set; }
    public Pokemon Pokemon { get; set; } = null;
}