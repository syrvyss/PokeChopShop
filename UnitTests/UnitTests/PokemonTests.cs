using Data.Entities;
using Data.Services.Repositories;
using Data.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql.PostgresTypes;

namespace UnitTests;

public class Pokemon_Tests
{
    private readonly PokemonRepository _repository;

    public Pokemon_Tests()
    {
        var options = new DbContextOptionsBuilder<Data.EfCoreContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new Data.EfCoreContext(options);

        // Inject the concrete implementation of the repository
        _repository = new PokemonRepository(context);
    }

    [Fact]
    public async void Should_CreatePokemonSuccessfully()
    {
        // Arrange
        var pokemon1 = new Pokemon
        {
            Id = 1,
            Name = "Bulbasaur",
            Sprite = await Sprite.GetSprite("https://pokeapi.co/api/v2/pokemon/1")
        };

        // Act
        _repository.Add(pokemon1);

        // Assert
        Assert.Equal(1, _repository.GetAll().Count());
    }

    [Fact]
    public async void Should_GetAllOrdersSuccessfully()
    {
        // Arrange
        var pokemon1 = new Pokemon
        {
            Id = 1,
            Name = "Bulbasaur",
            Sprite = await Sprite.GetSprite("https://pokeapi.co/api/v2/pokemon/1")
        };

        var pokemon2 = new Pokemon
        {
            Id = 2,
            Name = "Ivysaur",
            Sprite = await Sprite.GetSprite("https://pokeapi.co/api/v2/pokemon/2")
        };

        // Act
        _repository.Add(pokemon1);
        _repository.Add(pokemon2);

        // Assert
        Assert.Equal(2, _repository.GetAll().Count());
    }

    [Fact]
    public async void Should_UpdateOrderSuccessfully()
    {
        // Arrange
        var pokemon1 = new Pokemon
        {
            Id = 1,
            Name = "Bulbasaur",
            Sprite = await Sprite.GetSprite("https://pokeapi.co/api/v2/pokemon/1")
        };

        _repository.Add(pokemon1);

        // Act
        pokemon1.Name = "Peter";
        _repository.Update(pokemon1);

        var updatedPokemon = _repository.GetById(pokemon1.Id);

        // Assert
        Assert.Equal("Peter", updatedPokemon.Name);
    }

    [Fact]
    public async void Should_DeleteOrderSuccessfully()
    {
        // Arrange
        var pokemon1 = new Pokemon
        {
            Id = 1,
            Name = "Bulbasaur",
            Sprite = await Sprite.GetSprite("https://pokeapi.co/api/v2/pokemon/1")
        };

        // Act
        _repository.Add(pokemon1);

        _repository.Delete(pokemon1);

        // Assert
        Assert.Empty(_repository.GetAll());
    }
}