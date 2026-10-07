using System.ComponentModel.DataAnnotations;

namespace AdminShop.Models;

public class Customer
{
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; } = string.Empty;

    [EmailAddress]
    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Avatar { get; set; }

    public DateTime? Birthday { get; set; }

    public bool Gender { get; set; }

    public string? Password { get; set; }

    public string? Facebook { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}