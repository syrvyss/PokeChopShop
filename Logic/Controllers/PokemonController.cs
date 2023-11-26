using Data.Services;
using Data.Services.Interfaces;
using PokeShop.Shared.Dto;
using Logic.Mappers;

namespace Logic.Controllers;

public class PokemonController : IPokemonController
{
    protected readonly IPokemonRepository _repository;
    protected readonly Data.EfCoreContext _dbContext;

    public PokemonController(IPokemonRepository repository,
        Data.EfCoreContext dbContext)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _dbContext = dbContext;
    }

    // Base
    public PokemonDto? GetById(int id)
    {
        var pokemon = _repository.GetById(id);

        return pokemon?.ToDto();
    }

    public IEnumerable<PokemonDto> GetAll()
    {
        var pokemon = _repository.GetAll();
        var dto = pokemon.Select(x => x.ToDto());

        return dto;
    }

    public void Add(PokemonDto entity)
    {
        _repository.Add(entity.ToModel());
    }

    public void AddFull(PokemonDto entity, PokemonStatsDto entity2)
    {
        var pokemonModel = entity.ToModel();
        pokemonModel.PokemonStats = entity2.ToModel();

        Console.WriteLine(pokemonModel.PokemonStats);

        _repository.Add(pokemonModel);
    }

    public void Update(PokemonDto entity)
    {
        var pokemon = entity.ToModel();
        pokemon.Id = entity.Id;

        _repository.UpdateEntity(pokemon);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }

    // Extensions
    public PokemonDto? GetFullById(int id)
    {
        var pokemon = _repository.GetFullById(id);

        return pokemon?.ToDto();
    }

    public IEnumerable<PokemonDto> GetFullAll()
    {
        var pokemon = _repository.GetFullAll();
        var dto = pokemon.Select(x => x.ToDto());

        return dto;
    }

    public IEnumerable<PokemonDto> GetItemsOnPage(int pageNumber, int pageSize, string? filterQuery,
        string? searchQuery)
    {
        var pokemonOnPage = _repository.GetItemsOnPage(pageNumber, pageSize, filterQuery, searchQuery);
        var dto = pokemonOnPage.Select(x => x.ToDto());

        return dto;
    }
}