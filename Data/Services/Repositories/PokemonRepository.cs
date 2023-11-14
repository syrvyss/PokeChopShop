using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Repositories;

public class PokemonRepository : BaseRepository<Pokemon>, IPokemonRepository
{
    public PokemonRepository(EfCoreContext context) : base(context)
    {
    }

    public Pokemon? GetFullById(int id)
    {
        return _context.Pokemon
            .Where(e => e.Id == id)
            .Include(o => o.PokemonStats)
            .FirstOrDefault();
    }

    public IEnumerable<Pokemon> GetItemsOnPage(int pageNumber, int pageSize, string? filterQuery, string? searchQuery)
    {
        // Calculate the number of items to skip based on the page number and size
        var itemsToSkip = (pageNumber - 1) * pageSize;

        var getPokemon = _context.Pokemon
            .Include(o => o.PokemonStats)
            .ToList();

        getPokemon = filterQuery switch
        {
            "name" => getPokemon.OrderBy(x => x.Name).ToList(),
            "weight" => getPokemon.OrderBy(x => x.PokemonStats.Weight).ToList(),
            _ => getPokemon.OrderBy(x => x.Id).ToList()
        };

        if (!string.IsNullOrEmpty(searchQuery))
            getPokemon = getPokemon
                .Where(p => p.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                .ToList();

        // Query the database to get the paged results
        var pagedPokemons = getPokemon
            .Skip(itemsToSkip)
            .Take(pageSize)
            .ToList();

        return pagedPokemons;
    }
}