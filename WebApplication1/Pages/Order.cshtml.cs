using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using WebApplication1.Entities;

namespace WebApplication1.Pages;

public class Order : PageModel
{
    private readonly IOrderRepository _orderRepository;
    private readonly IPokemonRepository _pokemonRepository;
    private readonly IPokemonStatsRepository _pokemonStatsRepository;

    public List<BasketItem> BasketItems { get; private set; } = new();
    public List<Pokemon> FilteredPokemon { get; private set; } = new();

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
    [MinLength(15)]
    public string CardNumber { get; set; }

    [BindProperty]
    [Required]
    [StringLength(10)]
    [MinLength(10)]
    public string SocialSecurity { get; set; }

    public Order(IOrderRepository orderRepository, IPokemonRepository pokemonRepository,
        IPokemonStatsRepository pokemonStatsRepository)
    {
        _orderRepository = orderRepository;
        _pokemonRepository = pokemonRepository;
        _pokemonStatsRepository = pokemonStatsRepository;
    }

    public void OnGet()
    {
        var serializedData = Request.Cookies["basket"];

        var list = new List<BasketItem>();

        if (!string.IsNullOrEmpty(serializedData))
            list = JsonConvert.DeserializeObject<List<BasketItem>>(serializedData);

        BasketItems = list;

        var pokemonList = _pokemonRepository
            .GetAll()
            .Where(x => BasketItems.Select(x => x.PokemonId).Contains(x.Id))
            .ToList();

        pokemonList
            .ForEach(x => x.PokemonStats = _pokemonStatsRepository.GetById(x.Id));

        FilteredPokemon = pokemonList;
    }

    public IActionResult OnPostDelete(Guid id)
    {
        // ModelState.Clear();
        var serializedData = Request.Cookies["basket"];

        var updatedList = new List<BasketItem>();

        if (!string.IsNullOrEmpty(serializedData))
            updatedList = JsonConvert.DeserializeObject<List<BasketItem>>(serializedData);

        updatedList.RemoveAll(x => x.Id == id);

        Response.Cookies.Append("basket", JsonConvert.SerializeObject(updatedList), new CookieOptions
        {
            Expires = DateTimeOffset.Now.AddMinutes(30)
        });

        // return Page();
        return RedirectToPage("Order");
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        Data.Entities.CustomerInformation customerInformation = new()
        {
            Country = Country,
            Address = Address
        };

        var serializedData = Request.Cookies["basket"];

        var list = new List<BasketItem>();

        if (!string.IsNullOrEmpty(serializedData))
            list = JsonConvert.DeserializeObject<List<BasketItem>>(serializedData);

        BasketItems = list;

        var orderedPokemon = BasketItems
            .GroupBy(x => x.PokemonId) // Group the items by PokemonId
            .Select(group =>
            {
                var pokemon = _pokemonRepository.GetById(group.Key); // Get the Pokemon
                if (pokemon != null)
                {
                    pokemon.Quantity = group.Count(); // Assign the quantity
                    return pokemon;
                }

                return null;
            })
            .Where(x => x != null)
            .ToList();

        _orderRepository.Add(new Data.Entities.Order
        {
            Email = Email,
            CardDetails = CardNumber,
            SocialSecurity = SocialSecurity,
            CustomerInformation = customerInformation,
            Price = BasketItems.Select(x => x.Price).Sum(),
            OrderDate = DateTime.Now,
            Pokemon = orderedPokemon
        });

        Response.Cookies.Append("basket", JsonConvert.SerializeObject(new List<BasketItem>()), new CookieOptions
        {
            Expires = DateTimeOffset.Now.AddMinutes(30)
        });

        return RedirectToPage("Index");
    }
}