using System;
using System.Collections.Generic;

namespace Lesson09_Session_Cookie.Models.DBModel;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
