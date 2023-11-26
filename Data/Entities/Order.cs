using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class Order
{
    [Key] public int Id { get; set; }

    // Unencrypted plain-text personal information in strings,
    // taught by the very best (IT-Center Syd)
    [StringLength(255)]
    [EmailAddress]
    [Required]
    public string Email { get; set; }

    [StringLength(16)] [Required] public string CardDetails { get; set; }

    [Required] public double Price { get; set; }

    [StringLength(10)] [Required] public string SocialSecurity { get; set; }
    [Required] public DateTime OrderDate { get; set; }

    // Navigation
    public List<Pokemon> Pokemon { get; set; }

    public int CustomerInformationId { get; set; }
    public CustomerInformation CustomerInformation { get; set; }
}