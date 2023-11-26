using Data.Entities;
using PokeShop.Shared.Dto;

namespace Logic.Mappers;

public static class PokemonStatsExtensions
{
    public static PokemonStats ToModel(this PokemonStatsDto pokemonStatsDto)
    {
        return new PokemonStats()
        {
            Description = pokemonStatsDto.Description,
            Experience = pokemonStatsDto.Experience,
            Height = pokemonStatsDto.Height,
            Weight = pokemonStatsDto.Weight
        };
    }
}