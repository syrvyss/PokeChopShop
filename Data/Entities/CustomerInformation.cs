using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CustomerInformation
{
    public int Id { get; set; }

    [Required] public string Country { get; set; }

    [Required] public string Address { get; set; }

    // Navigation
    public int OrderId { get; set; }
    public Order Order { get; set; }
}