namespace Data.Entities;

public class CustomerInformation
{
    public int Id { get; set; }

    public string Country { get; set; }
    public string Address { get; set; }

    // Navigation
    public int OrderId { get; set; }
    public Order Order { get; set; }
}