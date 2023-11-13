using Data.Entities;

namespace Data.Interfaces;

public interface IPokemonRepository : IBaseRepository<Pokemon>
{
    Pokemon? GetFullById(int id);
    IEnumerable<Pokemon> GetItemsOnPage(int pageNumber, int pageSize, string? filterQuery, string? searchQuery);
}