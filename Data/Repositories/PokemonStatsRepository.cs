using Data.Entities;

namespace Data.Repositories;

public class PokemonStatsRepository : BaseRepository<PokemonStats>, IPokemonStatsRepository
{
    public PokemonStatsRepository(EfCoreContext context) : base(context)
    {
    }
}