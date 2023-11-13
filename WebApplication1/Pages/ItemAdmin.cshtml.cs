using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PokeChopShop.Pages;

public class ItemAdmin : PageModel
{
    private IPokemonRepository _pokemonRepository;
    private IPokemonStatsRepository _pokemonStatsRepository;

    public Pokemon Pokemon { get; set; }

    [BindProperty(SupportsGet = true)] public int Id { get; set; }

    [BindProperty] public string Name { get; set; }
    [BindProperty] public int Experience { get; set; }
    [BindProperty] public int Height { get; set; }
    [BindProperty] public int Weight { get; set; }
    [BindProperty] public string Description { get; set; }

    public ItemAdmin(IPokemonRepository pokemonRepository, IPokemonStatsRepository pokemonStatsRepository)
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

        var pokemon = _pokemonRepository.GetFullById(Id);
        // var pokemonStats = _pokemonStatsRepository.GetById(Id);

        pokemon.Name = Name;
        pokemon.PokemonStats.Experience = Experience;
        pokemon.PokemonStats.Height = Height;
        pokemon.PokemonStats.Weight = Weight;
        pokemon.PokemonStats.Description = Description;

        _pokemonRepository.Update(pokemon);
        // _pokemonStatsRepository.Update(pokemonStats);

        return RedirectToPage("Admin");
    }
}