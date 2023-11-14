using Data.Entities;
using Data.Services.Interfaces;

namespace WebAppAPI.Controllers;

public class OrderController : BaseController<Order>
{
    public OrderController(IOrderRepository repository) : base(repository)
    {
    }
}