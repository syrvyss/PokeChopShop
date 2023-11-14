using Data.Entities;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace PokeChopShop.Pages;

public class Shop : PageModel
{
    private readonly IPokemonRepository _pokemonRepository;

    public string SearchQuery { get; set; } = string.Empty;
    public string FilterQuery { get; set; } = string.Empty;
    public int PageId { get; private set; }
    public int PokemonCount { get; private set; } = 0;

    public List<Pokemon> PokemonOnPage { get; private set; }

    public Shop(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    public void OnGet(string searchQuery, int? pageId)
    {
        PageId = pageId ?? 1;

        var requestQuery = Request.Query["sort"];

        if (!string.IsNullOrEmpty(requestQuery))
            FilterQuery = requestQuery;

        SearchQuery = searchQuery;

        PokemonOnPage = _pokemonRepository
            .GetItemsOnPage(PageId, 10, FilterQuery, SearchQuery)
            .ToList();

        PokemonCount = _pokemonRepository.GetAll().Count();
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