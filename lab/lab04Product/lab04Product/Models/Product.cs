namespace lab04Product.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public byte Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}
