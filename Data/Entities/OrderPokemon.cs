using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class OrderPokemon
{
    [Required] public int PokemonId { get; set; }

    [Required] public int OrderId { get; set; }

    // Navigation
    public Order Order { get; set; }
    public Pokemon Pokemon { get; set; }
}