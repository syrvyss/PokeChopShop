using Data.Entities;

namespace Data.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Order? GetFullById(int id);
}