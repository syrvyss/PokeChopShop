using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class PokemonStatsRepository : BaseRepository<PokemonStats>, IPokemonStatsRepository
{
    public PokemonStatsRepository(EfCoreContext context) : base(context)
    {
    }
}