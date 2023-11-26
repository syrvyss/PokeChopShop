using Data.Entities;
using PokeShop.Shared.Dto;

namespace Logic.Mappers;

public static class PokemonExtensions
{
    public static Pokemon ToModel(this PokemonDto pokemonDto)
    {
        return new Pokemon()
        {
            Sprite = pokemonDto.Sprite,
            Name = pokemonDto.Name,
            Quantity = pokemonDto.Quantity
        };
    }
}