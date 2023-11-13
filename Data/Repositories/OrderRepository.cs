using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(EfCoreContext context) : base(context)
    {
    }

    public Order? GetFullById(int id)
    {
        return _context.Orders
            .Where(e => e.Id == id)
            .Include(o => o.Pokemon)
            .Include(o => o.CustomerInformation)
            .FirstOrDefault();
    }
}