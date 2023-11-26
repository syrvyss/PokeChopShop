using Logic.Controllers;
using PokeShop.Shared.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonStatsController(Logic.Controllers.IPokemonStatsController controller)
    : BaseController<PokemonStatsDto>(controller)
{
}