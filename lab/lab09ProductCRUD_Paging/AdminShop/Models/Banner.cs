using System.ComponentModel.DataAnnotations;

namespace AdminShop.Models;

public class Banner
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public int Status { get; set; } = 1;

    public int Priority { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public string? Image { get; set; }

    public string? Description { get; set; }
}