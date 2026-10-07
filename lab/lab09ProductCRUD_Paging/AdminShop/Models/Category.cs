using System.ComponentModel.DataAnnotations;
namespace AdminShop.Models;
public class Category {
     public int Id {get;set;}
     [Required,StringLength(150)] public string Name {get;set;}="";
     public int Status {get;set;}=1;
     public DateTime CreatedDate {get;set;}=DateTime.Now;
     public string? Image {get;set;}
     public string? Description {get;set;}
     public ICollection<Product> Products {get;set;}=new List<Product>();
}
