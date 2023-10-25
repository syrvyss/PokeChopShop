using Data.Entities;

namespace Data.Repositories;

public class PokemonRepository : BaseRepository<Pokemon>, IPokemonRepository
{
    public PokemonRepository(EfCoreContext context) : base(context)
    {
    }
}