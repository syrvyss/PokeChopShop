using Data.Entities;

namespace Data.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Order? GetFullById(int id);
}