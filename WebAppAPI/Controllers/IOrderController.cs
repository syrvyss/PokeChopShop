using PokeShop.Shared.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAPI.Controllers;

public interface IOrderController : IBaseController<FlatOrderDto>
{
}