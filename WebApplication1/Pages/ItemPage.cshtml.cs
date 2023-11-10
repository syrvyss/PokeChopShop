using System.ComponentModel.DataAnnotations;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebApplication1.Entities;

namespace PokeChopShop.Pages;

public class ItemPage : PageModel
{
    private IPokemonRepository _pokemonRepository;
    private IPokemonStatsRepository _pokemonStatsRepository;

    public Pokemon Pokemon { get; set; }

    [BindProperty(SupportsGet = true)] public int Id { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Please choose desired length.")]
    public double Weight { get; set; }

    public ItemPage(IPokemonRepository pokemonRepository, IPokemonStatsRepository pokemonStatsRepository)
    {
        _pokemonRepository = pokemonRepository;
        _pokemonStatsRepository = pokemonStatsRepository;
    }

    public void OnGet(int id)
    {
        ViewData["ItemId"] = id;
        Id = id;

        Pokemon = _pokemonRepository.GetFullById(id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid) return Page();

        var serializedData = Request.Cookies["basket"];

        List<BasketItem> list;

        if (string.IsNullOrEmpty(serializedData))
            list = new List<BasketItem>();
        else
            list = JsonConvert.DeserializeObject<List<BasketItem>>(serializedData);

        list.Add(
            new BasketItem()
            {
                PokemonId = Id,
                Price = (double)_pokemonStatsRepository.GetById(Id).Weight * (Weight / 3.0)
            }
        ); // Assuming GetById returns a Pokemon object

        Response.Cookies.Append("basket", JsonConvert.SerializeObject(list), new CookieOptions
        {
            Expires = DateTimeOffset.Now.AddMinutes(30)
        });

        return RedirectToPage("Order");
    }
}