using PokeShop.Shared.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAPI.Controllers;

public interface IPokemonController : IBaseController<PokemonDto>
{
}