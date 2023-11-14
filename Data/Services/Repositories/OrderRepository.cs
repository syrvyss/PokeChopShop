using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Repositories;

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