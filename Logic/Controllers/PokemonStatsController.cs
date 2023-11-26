using Data.Services;
using Data.Services.Interfaces;
using PokeShop.Shared.Dto;
using Logic.Mappers;

namespace Logic.Controllers;

public class PokemonStatsController : IPokemonStatsController
{
    protected readonly IPokemonStatsRepository _repository;

    public PokemonStatsController(IPokemonStatsRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    // Base
    public PokemonStatsDto? GetById(int id)
    {
        var pokemonStats = _repository.GetById(id);

        return pokemonStats?.ToDto();
    }

    public IEnumerable<PokemonStatsDto> GetAll()
    {
        var pokemonStats = _repository.GetAll();
        var dto = pokemonStats.Select(x => x.ToDto());

        return dto;
    }

    public void Add(PokemonStatsDto entity)
    {
        _repository.Add(entity.ToModel());
    }

    public void Update(PokemonStatsDto entity)
    {
        var pokemonStats = entity.ToModel();
        pokemonStats.Id = entity.Id;

        _repository.UpdateEntity(pokemonStats);
    }

    public void Delete(int id)
    {
        // _repository.Delete(pokemonStats);
    }
}