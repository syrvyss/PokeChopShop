using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

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
}