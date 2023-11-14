using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PokeChopShop.Pages;

public class Admin : PageModel
{
    private IPokemonRepository _pokemonRepository;
    private IOrderRepository _orderRepository;

    public Admin(IPokemonRepository pokemonRepository, IOrderRepository orderRepository)
    {
        _pokemonRepository = pokemonRepository;
        _orderRepository = orderRepository;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPostDeletePokemon(int id)
    {
        var getPokemon = _pokemonRepository.GetById(id);

        _pokemonRepository.Delete(getPokemon);
        return Page();
    }

    public IActionResult OnPostDeleteOrder(int id)
    {
        var getOrder = _orderRepository.GetById(id);

        _orderRepository.Delete(getOrder);
        return Page();
    }
}