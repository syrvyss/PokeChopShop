using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace UnitTests;

public class Pokemon_Tests
{
    [Fact]
    public void Should_CreatePokemonSuccessfully()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<Data.EfCoreContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using var context = new Data.EfCoreContext(options);
        var repository = new PokemonRepository(context);

        var pokemon1 = new Pokemon
        {
            Id = 1,
            Name = "Bulbasaur",
            Url = "https://pokeapi.co/api/v2/pokemon/1"
        };

        // Act
        repository.Add(pokemon1);

        // Assert
        Assert.Equal(1, context.Set<Pokemon>().Count());
    }

    [Fact]
    public void Should_GetAllOrdersSuccessfully()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<Data.EfCoreContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using var context = new Data.EfCoreContext(options);
        var repository = new PokemonRepository(context);

        var pokemon1 = new Pokemon
        {
            Id = 1,
            Name = "Bulbasaur",
            Url = "https://pokeapi.co/api/v2/pokemon/1"
        };

        var pokemon2 = new Pokemon
        {
            Id = 2,
            Name = "Ivysaur",
            Url = "https://pokeapi.co/api/v2/pokemon/2"
        };

        repository.Add(pokemon1);
        repository.Add(pokemon2);

        // Act
        var allPokemon = repository.GetAll();

        // Assert
        Assert.Equal(2, allPokemon.Count());
    }

    [Fact]
    public void Should_UpdateOrderSuccessfully()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<Data.EfCoreContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using var context = new Data.EfCoreContext(options);
        var repository = new PokemonRepository(context);

        var pokemon1 = new Pokemon
        {
            Id = 1,
            Name = "Bulbasaur",
            Url = "https://pokeapi.co/api/v2/pokemon/1"
        };

        repository.Add(pokemon1);

        // Act
        pokemon1.Name = "Peter";
        repository.Update(pokemon1);

        var updatedPokemon = repository.GetById(pokemon1.Id);

        // Assert
        Assert.Equal("Peter", updatedPokemon.Name);
    }

    [Fact]
    public void Should_DeleteOrderSuccessfully()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<Data.EfCoreContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using var context = new Data.EfCoreContext(options);
        var repository = new PokemonRepository(context);

        var pokemon1 = new Pokemon
        {
            Id = 1,
            Name = "Bulbasaur",
            Url = "https://pokeapi.co/api/v2/pokemon/1"
        };

        // Act
        repository.Add(pokemon1);

        repository.Delete(pokemon1);

        // Assert
        Assert.Equal(0, context.Set<Pokemon>().Count());
    }
}