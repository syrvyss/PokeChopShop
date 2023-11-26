using Data.Services.Interfaces;
using PokeShop.Shared.Dto;

namespace Logic.Controllers;

public interface IPokemonController : IBaseController<PokemonDto>
{
    public void AddFull(PokemonDto entity, PokemonStatsDto entity2);

    public IEnumerable<PokemonDto> GetItemsOnPage(int pageNumber, int pageSize, string? filterQuery,
        string? searchQuery);
}