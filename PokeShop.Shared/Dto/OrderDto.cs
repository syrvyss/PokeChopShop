using Data.Entities;

namespace PokeShop.Shared.Dto;

public class OrderDto
{
    public int Id { get; set; }

    public string Email { get; set; }
    public string CardDetails { get; set; }
    public double Price { get; set; }
    public string SocialSecurity { get; set; }
    public DateTime OrderDate { get; set; }
}

public static class OrderExtensions
{
    public static OrderDto ToDto(this Order order)
    {
        return new OrderDto()
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