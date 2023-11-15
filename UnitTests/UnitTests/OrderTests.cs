using Data.Entities;
using Data.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace UnitTests;

public class Order_Tests
{
    private readonly OrderRepository _repository;

    public Order_Tests()
    {
        var options = new DbContextOptionsBuilder<Data.EfCoreContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new Data.EfCoreContext(options);

        // Inject the concrete implementation of the repository
        _repository = new OrderRepository(context);
    }

    [Fact]
    public void Should_CreateOrderSuccessfully()
    {
        // Arrange
        var order1 = new Order
        {
            Email = "a@gmail.com",
            CardDetails = "0000000000000000",
            SocialSecurity = "0000000000",
            CustomerInformation = new Data.Entities.CustomerInformation()
            {
                Country = "dammag",
                Address = "dammg koldin"
            },
            Price = 1,
            OrderDate = DateTime.Now,
            Pokemon = new List<Pokemon>()
        };

        // Act
        _repository.Add(order1);

        // Assert
        Assert.Equal(_repository.GetAll().Count(), 1);
    }

    [Fact]
    public void Should_GetAllOrdersSuccessfully()
    {
        // Arrange
        var order1 = new Order
        {
            Email = "a@gmail.com",
            CardDetails = "0000000000000000",
            SocialSecurity = "0000000000",
            CustomerInformation = new Data.Entities.CustomerInformation()
            {
                Country = "dammag",
                Address = "dammg koldin"
            },
            Price = 1,
            OrderDate = DateTime.Now,
            Pokemon = new List<Pokemon>()
        };
        var order2 = new Order
        {
            Email = "a@gmail.com",
            CardDetails = "0000000000000000",
            SocialSecurity = "0000000000",
            CustomerInformation = new Data.Entities.CustomerInformation()
            {
                Country = "dammag",
                Address = "dammg koldin"
            },
            Price = 1,
            OrderDate = DateTime.Now,
            Pokemon = new List<Pokemon>()
        };


        // Act
        _repository.Add(order1);
        _repository.Add(order2);

        // Assert
        Assert.Equal(_repository.GetAll().Count(), 2);
    }

    [Fact]
    public void Should_UpdateOrderSuccessfully()
    {
        // Arrange
        var order1 = new Order
        {
            Email = "a@gmail.com",
            CardDetails = "0000000000000000",
            SocialSecurity = "0000000000",
            CustomerInformation = new Data.Entities.CustomerInformation()
            {
                Country = "dammag",
                Address = "dammg koldin"
            },
            Price = 1,
            OrderDate = DateTime.Now,
            Pokemon = new List<Pokemon>()
        };

        _repository.Add(order1);

        // Act
        order1.Email = "updated_email@example.com";
        _repository.Update(order1);

        var updatedOrder = _repository.GetById(order1.Id);

        // Assert
        Assert.Equal("updated_email@example.com", updatedOrder.Email);
    }

    [Fact]
    public void Should_DeleteOrderSuccessfully()
    {
        // Arrange
        var order1 = new Order
        {
            Email = "a@gmail.com",
            CardDetails = "0000000000000000",
            SocialSecurity = "0000000000",
            CustomerInformation = new Data.Entities.CustomerInformation()
            {
                Country = "dammag",
                Address = "dammg koldin"
            },
            Price = 1,
            OrderDate = DateTime.Now,
            Pokemon = new List<Pokemon>()
        };

        // Act
        _repository.Add(order1);

        _repository.Delete(order1);

        // Assert
        Assert.Empty(_repository.GetAll());
    }
}