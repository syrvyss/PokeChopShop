using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Repositories;

public class PokemonStatsRepository : BaseRepository<PokemonStats>, IPokemonStatsRepository
{
    public PokemonStatsRepository(EfCoreContext context) : base(context)
    {
    }

    public void UpdateEntity(PokemonStats pokemonStats)
    {
        var findStats = _context.PokemonStats.Find(pokemonStats.Id);

        findStats.Experience = pokemonStats.Experience;
        findStats.Height = pokemonStats.Height;
        findStats.Weight = pokemonStats.Weight;
        findStats.Description = pokemonStats.Description;

        _context.SaveChanges();
    }
}