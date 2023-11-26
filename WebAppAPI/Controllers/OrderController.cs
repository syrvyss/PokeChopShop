using Logic.Controllers;
using PokeShop.Shared.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(Logic.Controllers.IOrderController controller)
    : BaseController<FlatOrderDto>(controller), IOrderController
{
}