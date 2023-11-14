using Data.Entities;
using Data.Services.Interfaces;

namespace WebAppAPI.Controllers;

public class PokemonController : BaseController<Pokemon>
{
    public PokemonController(IPokemonRepository repository) : base(repository)
    {
    }
}