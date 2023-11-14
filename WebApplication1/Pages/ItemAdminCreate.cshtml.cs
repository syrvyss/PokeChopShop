using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PokeChopShop.Pages;

public class ItemAdminCreate : PageModel
{
    private IPokemonRepository _pokemonRepository;
    private IPokemonStatsRepository _pokemonStatsRepository;

    [BindProperty] public string Name { get; set; }
    [BindProperty] public string Sprite { get; set; }
    [BindProperty] public int Experience { get; set; }
    [BindProperty] public int Height { get; set; }
    [BindProperty] public int Weight { get; set; }
    [BindProperty] public string Description { get; set; }

    public ItemAdminCreate(IPokemonRepository pokemonRepository, IPokemonStatsRepository pokemonStatsRepository)
    {
        _pokemonRepository = pokemonRepository;
        _pokemonStatsRepository = pokemonStatsRepository;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid) return Page();

        var maxId = _pokemonRepository.GetAll().MaxBy(x => x.Id).Id;


        var pokemon = new Pokemon()
        {
            Id = maxId + 1,
            Name = Name,
            Sprite = Sprite,
            Quantity = 0,
            Orders = new List<Order>(),
            PokemonStats = new PokemonStats()
            {
                Id = maxId + 1,
                Experience = Experience,
                Height = Height,
                Weight = Weight,
                Description = Description
            }
        };

        _pokemonRepository.Add(pokemon);

        return RedirectToPage("Admin");
    }
}