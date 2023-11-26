using Data.Entities;

namespace PokeShop.Shared.Dto;

public static class CustomerInformationExtensions
{
    public static CustomerInformation ToModel(this CustomerInformationDto customerInformationDto)
    {
        return new CustomerInformation()
        {
            Id = customerInformationDto.Id,

            Address = customerInformationDto.Address,
            Country = customerInformationDto.Country
        };
    }
}