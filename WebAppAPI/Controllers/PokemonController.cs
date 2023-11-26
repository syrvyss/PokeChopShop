using PokeShop.Shared.Dto;
using Logic.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebAppBlazor.Entities;

namespace WebAppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : BaseController<PokemonDto>, IPokemonController
{
    private readonly Logic.Controllers.IPokemonController _controller;

    public PokemonController(Logic.Controllers.IPokemonController controller)
        : base(controller)
    {
        _controller = controller;
    }


    [HttpPost("AddFull")]
    public ActionResult<PokemonDto> AddFull(PokemonViewModel entity)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _controller.AddFull(entity.Pokemon, entity.PokemonStats);

        return Ok();
    }
}