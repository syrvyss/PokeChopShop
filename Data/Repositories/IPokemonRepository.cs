using Data.Entities;

namespace Data.Repositories;

public interface IPokemonRepository : IBaseRepository<Pokemon>
{
    Pokemon? GetFullById(int id);
}