using Data.Entities;

namespace Data.Services.Interfaces;

public interface IPokemonStatsRepository : IBaseRepository<PokemonStats>
{
    public void UpdateEntity(PokemonStats pokemonStats);
}