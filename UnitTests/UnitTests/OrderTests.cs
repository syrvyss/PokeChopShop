using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace UnitTests;

public class Order_Tests
{
    [Fact]
    public void Should_CreateOrderSuccessfully()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<Data.EfCoreContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using var context = new Data.EfCoreContext(options);
        var repository = new OrderRepository(context);

        var order1 = new Order
        {
            Id = 1,
            Email = "a@gmail.com",
            CardDetails = "1234 5678 9123 4567",
            SocialSecurity = "12 34 56 7891",
            OrderDate = DateTime.Now,
            PokemonId = 1
        };

        // Act
        repository.Add(order1);

        // Assert
        Assert.Equal(1, context.Set<Order>().Count());
    }

    [Fact]
    public void Should_GetAllOrdersSuccessfully()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<Data.EfCoreContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using var context = new Data.EfCoreContext(options);
        var repository = new OrderRepository(context);

        var order1 = new Order
        {
            Id = 1,
            Email = "a@gmail.com",
            CardDetails = "1234 5678 9123 4567",
            SocialSecurity = "12 34 56 7891",
            OrderDate = DateTime.Now,
            PokemonId = 1
        };

        var order2 = new Order
        {
            Id = 2,
            Email = "b@gmail.com",
            CardDetails = "5678 9123 4567 1234",
            SocialSecurity = "34 56 7891 12",
            OrderDate = DateTime.Now,
            PokemonId = 2
        };

        repository.Add(order1);
        repository.Add(order2);

        // Act
        var allOrders = repository.GetAll();

        // Assert
        Assert.Equal(2, allOrders.Count());
    }

    [Fact]
    public void Should_UpdateOrderSuccessfully()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<Data.EfCoreContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using var context = new Data.EfCoreContext(options);
        var repository = new OrderRepository(context);

        var order1 = new Order
        {
            Id = 1,
            Email = "a@gmail.com",
            CardDetails = "1234 5678 9123 4567",
            SocialSecurity = "12 34 56 7891",
            OrderDate = DateTime.Now,
            PokemonId = 1
        };

        repository.Add(order1);

        // Act
        order1.Email = "updated_email@example.com";
        repository.Update(order1);

        var updatedOrder = repository.GetById(order1.Id);

        // Assert
        Assert.Equal("updated_email@example.com", updatedOrder.Email);
    }

    [Fact]
    public void Should_DeleteOrderSuccessfully()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<Data.EfCoreContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using var context = new Data.EfCoreContext(options);

        var repository = new OrderRepository(context);

        var order1 = new Order
        {
            Id = 1,
            Email = "a@gmail.com",
            CardDetails = "1234 5678 9123 4567",
            SocialSecurity = "12 34 56 7891",
            OrderDate = DateTime.Now,
            PokemonId = 1
        };

        // Act
        repository.Add(order1);

        repository.Delete(order1);

        // Assert
        Assert.Equal(0, context.Set<Order>().Count());
    }
}