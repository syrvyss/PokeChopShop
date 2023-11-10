using System.Net;
using System.Text.Json;
using Data.Entities;
using Data.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace Data;

public class EfCoreContextFactory : IDesignTimeDbContextFactory<EfCoreContext>
{
    public EfCoreContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<EfCoreContext>();
        builder
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
            .UseNpgsql(
                "Host=localhost;Database=postgres;Username=dkNikLue;Password=12345");
        return new EfCoreContext(builder.Options);
    }
}

public class EfCoreContext : DbContext
{
    public DbSet<Pokemon> Pokemon => Set<Pokemon>();
    public DbSet<PokemonStats> PokemonStats => Set<PokemonStats>();
    public DbSet<CustomerInformation> CustomerInformation => Set<CustomerInformation>();
    public DbSet<Order> Orders => Set<Order>();

    public EfCoreContext(DbContextOptions<EfCoreContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            optionsBuilder
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .UseNpgsql(
                    "Host=localhost;Database=postgres;Username=dkNikLue;Password=12345");
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Configuration.EfCoreContext).Assembly);

        SeedDataAsync(modelBuilder).GetAwaiter().GetResult();
    }

    private async Task SeedDataAsync(ModelBuilder modelBuilder)
    {
        // Adding example orders
        var customerInformation1 = new CustomerInformation()
        {
            Id = 1,
            Country = "Denmark",
            Address = "etstedidanmark",
            OrderId = 1
        };

        var order1 = new Order
        {
            Id = 1,
            Email = "a@gmail.com",
            CardDetails = "1234567891234567",
            SocialSecurity = "1234567891",
            OrderDate = DateTime.UtcNow
        };

        modelBuilder.Entity<CustomerInformation>().HasData(customerInformation1);
        modelBuilder.Entity<Order>().HasData(order1);
        // Adding example Pokémon
        // Pokémon 1 - Bulbasaur
        var pokemonStats1 = new PokemonStats
        {
            Id = 1,
            Experience = 64,
            Height = 7,
            Weight = 69,
            Description = "A grass and poison type Pokémon.",
            PokemonId = 1
        };

        var sprite = await Sprite.GetSprite("https://pokeapi.co/api/v2/pokemon/1");
        var pokemon1 = new Pokemon
        {
            Id = 1,
            Name = "Bulbasaur",
            Sprite = sprite
        };

        modelBuilder.Entity<PokemonStats>().HasData(pokemonStats1);
        modelBuilder.Entity<Pokemon>().HasData(pokemon1);

        // Pokémon 2 - Ivysaur
        var pokemonStats2 = new PokemonStats
        {
            Id = 2,
            Experience = 100,
            Height = 10,
            Weight = 100,
            Description = "Evolution of Bulbasaur.",
            PokemonId = 2
        };

        var sprite2 = await Sprite.GetSprite("https://pokeapi.co/api/v2/pokemon/2");
        var pokemon2 = new Pokemon
        {
            Id = 2,
            Name = "Ivysaur",
            Sprite = sprite2
        };

        modelBuilder.Entity<PokemonStats>().HasData(pokemonStats2);
        modelBuilder.Entity<Pokemon>().HasData(pokemon2);

        // Pokémon 3 - Venusaur
        var pokemonStats3 = new PokemonStats
        {
            Id = 3,
            Experience = 103,
            Height = 13,
            Weight = 130,
            Description = "Final evolution of Bulbasaur.",
            PokemonId = 3
        };

        var sprite3 = await Sprite.GetSprite("https://pokeapi.co/api/v2/pokemon/3");
        var pokemon3 = new Pokemon
        {
            Id = 3,
            Name = "Venusaur",
            Sprite = sprite3
        };

        modelBuilder.Entity<PokemonStats>().HasData(pokemonStats3);
        modelBuilder.Entity<Pokemon>().HasData(pokemon3);

        // Pokémon 4 - Charmander
        var pokemonStats4 = new PokemonStats
        {
            Id = 4,
            Experience = 120,
            Height = 6,
            Weight = 85,
            Description = "A fire-type Pokémon.",
            PokemonId = 4
        };

        var sprite4 = await Sprite.GetSprite("https://pokeapi.co/api/v2/pokemon/4");
        var pokemon4 = new Pokemon
        {
            Id = 4,
            Name = "Charmander",
            Sprite = sprite4
        };

        modelBuilder.Entity<PokemonStats>().HasData(pokemonStats4);
        modelBuilder.Entity<Pokemon>().HasData(pokemon4);

        // Pokémon 5 - Charmeleon
        var pokemonStats5 = new PokemonStats
        {
            Id = 5,
            Experience = 140,
            Height = 11,
            Weight = 190,
            Description = "Evolution of Charmander.",
            PokemonId = 5
        };

        var sprite5 = await Sprite.GetSprite("https://pokeapi.co/api/v2/pokemon/5");
        var pokemon5 = new Pokemon
        {
            Id = 5,
            Name = "Charmeleon",
            Sprite = sprite5
        };

        modelBuilder.Entity<PokemonStats>().HasData(pokemonStats5);
        modelBuilder.Entity<Pokemon>().HasData(pokemon5);

        // Pokémon 6 - Charizard
        var pokemonStats6 = new PokemonStats
        {
            Id = 6,
            Experience = 200,
            Height = 17,
            Weight = 905,
            Description = "Final evolution of Charmander.",
            PokemonId = 6
        };

        var sprite6 = await Sprite.GetSprite("https://pokeapi.co/api/v2/pokemon/6");
        var pokemon6 = new Pokemon
        {
            Id = 6,
            Name = "Charizard",
            Sprite = sprite6
        };

        modelBuilder.Entity<PokemonStats>().HasData(pokemonStats6);
        modelBuilder.Entity<Pokemon>().HasData(pokemon6);
    }
}