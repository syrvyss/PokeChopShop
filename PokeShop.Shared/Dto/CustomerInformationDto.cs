using Data.Entities;

namespace PokeShop.Shared.Dto;

public class CustomerInformationDto
{
    public int Id { get; set; }

    public string Country { get; set; }
    public string Address { get; set; }
    public int OrderId { get; set; }
}

public static class CustomerInformationExtensions
{
    public static CustomerInformationDto ToDto(this CustomerInformation customerInformation)
    {
        return new CustomerInformationDto()
        {
            Id = customerInformation.Id,
            Country = customerInformation.Country,
            OrderId = customerInformation.OrderId
        };
    }
}