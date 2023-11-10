using System.ComponentModel.DataAnnotations;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace PokeChopShop.Pages;

public class Shop : PageModel
{
    private readonly IPokemonRepository _pokemonRepository;

    public string SearchQuery { get; set; } = string.Empty;
    public List<Pokemon> PokemonItems { get; private set; }

    public Shop(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    public void OnGet(string searchQuery)
    {
        var requestQuery = Request.Query["sort"];
        if (!string.IsNullOrEmpty(requestQuery))
            SearchQuery = requestQuery;
        // var requestQuery = Request.Query["sort"];
        //
        // if (!string.IsNullOrEmpty(requestQuery))
        //     SearchQuery = requestQuery;
        //
        // var allPokemon = _pokemonRepository
        //     .GetAll()
        //     .ToList();
        //
        // allPokemon.ForEach(x =>
        // {
        //     var fullPokemon = _pokemonRepository.GetFullById(x.Id);
        //     x.PokemonStats = fullPokemon != null ? fullPokemon.PokemonStats : new PokemonStats();
        // });
        //
        // allPokemon = SearchQuery switch
        // {
        //     "name" => allPokemon.OrderBy(x => x.Name).ToList(),
        //     "weight" => allPokemon.OrderBy(x => x.PokemonStats.Weight).ToList(),
        //     _ => allPokemon.OrderBy(x => x.Id).ToList()
        // };
        //
        // if (!string.IsNullOrEmpty(SearchQuery))
        //     allPokemon = allPokemon
        //         .Where(p => p.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
        //         .ToList();
        //
        // PokemonItems = allPokemon;
        //
        var allPokemon = _pokemonRepository.GetAll().ToList();

        allPokemon.ForEach(x =>
        {
            var fullPokemon = _pokemonRepository.GetFullById(x.Id);
            x.PokemonStats = fullPokemon != null ? fullPokemon.PokemonStats : new PokemonStats();
        });

        if (!string.IsNullOrEmpty(searchQuery))
            allPokemon = allPokemon
                .Where(p => p.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                .ToList();

        allPokemon = SearchQuery switch
        {
            "name" => allPokemon.OrderBy(x => x.Name).ToList(),
            "weight" => allPokemon.OrderBy(x => x.PokemonStats.Weight).ToList(),
            _ => allPokemon.OrderBy(x => x.Id).ToList()
        };

        PokemonItems = allPokemon;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        var existingQueries = Request.Query; // Get existing query parameters

        var newQueries = new Dictionary<string, string>
        {
            { "sort", existingQueries["sort"] }, // Preserving the existing 'sort' query parameter
            { "SearchQuery", SearchQuery } // Adding the new 'SearchQuery'
        };

        var newQueryString = QueryHelpers.AddQueryString("", newQueries);

        return RedirectToPage("/shop", new { newQueryString });
    }
}

public static class IEnumerableExtensions
{
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
    {
        return self.Select((item, index) => (item, index));
    }
}