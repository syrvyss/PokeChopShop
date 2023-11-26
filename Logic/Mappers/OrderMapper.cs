using Data.Configuration;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using PokeShop.Shared.Dto;

namespace Logic.Mappers;

public static class OrderExtensions
{
    public static OrderDto ToDto(this FlatOrderDto flatOrderDto)
    {
        return new OrderDto()
        {
            Id = flatOrderDto.Id,
            Email = flatOrderDto.Email,
            CardDetails = flatOrderDto.CardDetails,
            Price = flatOrderDto.Price,
            SocialSecurity = flatOrderDto.SocialSecurity,
            OrderDate = flatOrderDto.OrderDate
        };
    }

    public static Order ToModel(this FlatOrderDto flatOrderDto, Data.EfCoreContext context)
    {
        var order = new Order()
        {
            Email = flatOrderDto.Email,
            CardDetails = flatOrderDto.CardDetails,
            Price = flatOrderDto.Price,
            SocialSecurity = flatOrderDto.SocialSecurity,
            OrderDate = flatOrderDto.OrderDate,

            CustomerInformation = new CustomerInformation()
            {
                Country = flatOrderDto.CustomerInformationDto.Country,
                Address = flatOrderDto.CustomerInformationDto.Address
            },
            Pokemon = new List<Pokemon>()
        };

        flatOrderDto.Pokemon.ForEach(pokemonDto =>
        {
            var existingPokemon = context.Pokemon.Find(pokemonDto.Id);
            if (existingPokemon != null)
            {
                // Attach the existing Pokemon entity to the context
                context.Attach(existingPokemon);

                // Set the state of the existing Pokemon entity to Unchanged
                context.Entry(existingPokemon).State = EntityState.Unchanged;

                // Add the existing Pokemon entity to the order.Pokemon collection
                order.Pokemon.Add(existingPokemon);
            }
            else
            {
                throw new InvalidOperationException($"Pokemon with Id {pokemonDto.Id} not found.");
            }
        });

        return order;
    }
}