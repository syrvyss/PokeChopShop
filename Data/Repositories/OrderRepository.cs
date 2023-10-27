using Data.Entities;

namespace Data.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(EfCoreContext context) : base(context)
    {
    }
}