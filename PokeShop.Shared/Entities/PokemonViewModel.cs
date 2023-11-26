using Data.Entities;
using PokeShop.Shared.Dto;

namespace WebAppBlazor.Entities;

public class PokemonViewModel
{
    public PokemonDto Pokemon { get; set; }
    public PokemonStatsDto PokemonStats { get; set; }
}