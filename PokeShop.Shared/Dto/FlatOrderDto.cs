using Data.Entities;

namespace PokeShop.Shared.Dto;

public class FlatOrderDto : IFlatOrderDto
{
    public int Id { get; set; }

    public string Email { get; set; }
    public string CardDetails { get; set; }
    public double Price { get; set; }
    public string SocialSecurity { get; set; }
    public DateTime OrderDate { get; set; }

    public CustomerInformationDto CustomerInformationDto { get; set; }
    public List<PokemonDto> Pokemon { get; set; }
}

public static class FlatOrderExtensions
{
    public static FlatOrderDto ToFlat(this Order order)
    {
        return new FlatOrderDto()
        {
            Id = order.Id,

            Email = order.Email,
            CardDetails = order.CardDetails,
            Price = order.Price,
            SocialSecurity = order.SocialSecurity,
            OrderDate = order.OrderDate
        };
    }
}