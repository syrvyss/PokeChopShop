using Data.Entities;

namespace Data.Services.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Order? GetFullById(int id);
}