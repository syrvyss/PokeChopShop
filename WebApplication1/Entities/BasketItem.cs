using Data.Entities;

namespace WebApplication1.Entities;

public class BasketItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int PokemonId { get; init; }
    public double Price { get; init; }
}