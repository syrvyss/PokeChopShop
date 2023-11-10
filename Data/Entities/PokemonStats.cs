using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class PokemonStats
{
    public int Id { get; set; }

    [Required] public int Experience { get; set; }
    [Required] public int Height { get; set; }
    [Required] public int Weight { get; set; }
    public string Description { get; set; }

    // Navigation
    public int PokemonId { get; set; }
    public Pokemon Pokemon { get; set; } = null;
}