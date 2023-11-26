using Data.Entities;
using Data.Services.Interfaces;
using PokeShop.Shared.Dto;

namespace Logic.Controllers;

public interface IPokemonStatsController : IBaseController<PokemonStatsDto>
{
}