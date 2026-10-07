namespace AdminShop.Models;

public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public Customer? Customer { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public int Status { get; set; } = 1;

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}