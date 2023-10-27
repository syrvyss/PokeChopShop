using System.Net;
using System.Text.Json;
using Data.Entities;
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
            OrderDate = DateTime.UtcNow,
            PokemonId = 1
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

        var pokemon1 = new Pokemon
        {
            Id = 1,
            Name = "Bulbasaur",
            Url = "https://pokeapi.co/api/v2/pokemon/1"
        };

        modelBuilder.Entity<PokemonStats>().HasData(pokemonStats1);
        modelBuilder.Entity<Pokemon>().HasData(pokemon1);
    }
}