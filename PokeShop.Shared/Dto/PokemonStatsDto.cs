using Data.Entities;

namespace PokeShop.Shared.Dto;

public class PokemonStatsDto
{
    public int Id { get; set; }

    public int Experience { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public string Description { get; set; }
}

public static class PokemonStatsExtensions
{
    public static PokemonStatsDto ToDto(this PokemonStats pokemonStats)
    {
        return new PokemonStatsDto()
        {
            Id = pokemonStats.Id,
            Experience = pokemonStats.Experience,
            Height = pokemonStats.Height,
            Weight = pokemonStats.Weight,
            Description = pokemonStats.Description
        };
    }
}