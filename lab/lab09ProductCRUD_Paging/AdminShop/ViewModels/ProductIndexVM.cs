using AdminShop.Models;

namespace AdminShop.ViewModels;

public class ProductIndexVM
{
    public List<Product> Items { get; set; } = [];
    public string? Keyword { get; set; }
    public int Page { get; set; }
    public int TotalPages { get; set; }
}