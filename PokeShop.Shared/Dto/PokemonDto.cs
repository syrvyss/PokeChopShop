using Data.Entities;

namespace PokeShop.Shared.Dto;

public class PokemonDto
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Sprite { get; set; }
    public int Quantity { get; set; }
}

public static class PokemonExtensions
{
    public static PokemonDto ToDto(this Pokemon pokemon)
    {
        return new PokemonDto()
        {
            Id = pokemon.Id,
            Name = pokemon.Name,
            Sprite = pokemon.Sprite,
            Quantity = pokemon.Quantity
        };
    }
}