using System;
using System.Collections.Generic;

namespace EFCoreDB.lesson06.Models.DBModel;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
