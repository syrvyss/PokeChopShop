using Data.Configuration;
using Data.Entities;
using Data.Services;
using Data.Services.Interfaces;
using PokeShop.Shared.Dto;
using Logic.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Logic.Controllers;

public class OrderController : IOrderController
{
    protected readonly IOrderRepository _repository;
    protected readonly Data.EfCoreContext _dbcontext;

    public OrderController(IOrderRepository repository, Data.EfCoreContext dbContext)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _dbcontext = dbContext;
    }

    // Base
    public FlatOrderDto? GetById(int id)
    {
        var order = _repository.GetById(id);

        return order?.ToFlat();
    }

    public IEnumerable<FlatOrderDto> GetAll()
    {
        var order = _repository.GetAll();
        var dto = order.Select(x => x.ToFlat());

        return dto;
    }

    public void Add(FlatOrderDto entity)
    {
        _repository.Add(entity.ToModel(_dbcontext));
    }

    public void Update(FlatOrderDto entity)
    {
        // _repository.Update(order);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}