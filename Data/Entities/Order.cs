using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class Order
{
    public int Id { get; set; }

    // Unencrypted plain-text personal information in strings,
    // taught by the very best (IT-Center Syd)
    [StringLength(255)] [EmailAddress] public string Email { get; set; }

    [StringLength(16)] [CreditCard] public string CardDetails { get; set; }

    [StringLength(10)] public string SocialSecurity { get; set; }
    public DateTime OrderDate { get; set; }

    public List<Pokemon> Pokemon { get; set; }

    // Navigation
    public int PokemonId { get; set; }
    public int CustomerInformationId { get; set; }
    public CustomerInformation CustomerInformation { get; set; }
}