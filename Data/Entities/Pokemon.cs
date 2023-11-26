using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class Pokemon
{
    [Key]
    public int Id { get; set; }

    [Required] public string Name { get; set; }
    [Required] public required string Sprite { get; set; }
    [Required] public int Quantity { get; set; }

    // Navigation
    public List<Order> Orders { get; set; }

    public PokemonStats PokemonStats { get; set; }
}