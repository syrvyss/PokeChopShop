using System.ComponentModel.DataAnnotations;
using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;

public class OrderAdmin : PageModel
{
    private readonly IOrderRepository _orderRepository;
    private readonly IPokemonRepository _pokemonRepository;

    public Data.Entities.Order Order { get; set; }

    [BindProperty(SupportsGet = true)] public int OrderId { get; set; }

    [BindProperty]
    [Required]
    [MinLength(3)]
    [StringLength(50)]
    public string Country { get; set; }

    [BindProperty]
    [Required]
    [MinLength(8)]
    [StringLength(255)]
    public string Address { get; set; }

    [BindProperty]
    [Required]
    [StringLength(255)]
    [EmailAddress]
    public string Email { get; set; }

    [BindProperty]
    [Required]
    [StringLength(16)]
    [MinLength(16)]
    [CreditCard]
    public string CardNumber { get; set; }

    [BindProperty]
    [Required]
    [StringLength(10)]
    [MinLength(10)]
    public string SocialSecurity { get; set; }

    public OrderAdmin(IOrderRepository orderRepository, IPokemonRepository pokemonRepository,
        IPokemonStatsRepository pokemonStatsRepository, ICustomerInformation customerInformation)
    {
        _orderRepository = orderRepository;
        _pokemonRepository = pokemonRepository;
    }

    public void OnGet(int id)
    {
        ViewData["ItemId"] = id;
        Id = id;

        Order = _orderRepository.GetFullById(id);
    }

    public IActionResult OnPostDelete(int id)
    {
        var pokemon = _pokemonRepository.GetFullById(id);
        var order = _orderRepository.GetFullById(Id);

        if (pokemon.Quantity > 1)
        {
            pokemon.Quantity -= 1;
            order.Pokemon.FirstOrDefault(x => x.Id == id).Quantity = pokemon.Quantity;
            _orderRepository.Update(order);
            // _pokemonRepository.Update(pokemon);
        }
        else
        {
            order?.Pokemon.Remove(pokemon);
            _orderRepository.Update(order);
        }

        return RedirectToPage("OrderAdmin");
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        Order = _orderRepository.GetFullById(Id);

        Order.Email = Email;
        Order.CardDetails = CardNumber;
        Order.SocialSecurity = SocialSecurity;
        Order.CustomerInformation.Country = Country;
        Order.CustomerInformation.Address = Address;

        _orderRepository.Update(Order);

        return RedirectToPage("Index");
    }
}