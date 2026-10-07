using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdminShop.Models;
public class Product {
     public int Id {get;set;}
     [Required,StringLength(200)] public string Name {get;set;}="";
     public string? Image {get;set;}
     [Column(TypeName="decimal(18,2)")] public decimal Price {get;set;}
     [Column(TypeName="decimal(18,2)")] public decimal SalePrice {get;set;}
     public int Status {get;set;}=1;
     public string? Description {get;set;}
     [Display(Name="Category")] public int CategoryId {get;set;}
     public Category? Category {get;set;}
     public DateTime CreatedDate {get;set;}=DateTime.Now;
     public ICollection<OrderDetail> OrderDetails {get;set;}=new List<OrderDetail>();
}
