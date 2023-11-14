using Data.Entities;
using Data.Services.Interfaces;

namespace Data.Services.Repositories;

public class PokemonStatsRepository : BaseRepository<PokemonStats>, IPokemonStatsRepository
{
    public PokemonStatsRepository(EfCoreContext context) : base(context)
    {
    }
}