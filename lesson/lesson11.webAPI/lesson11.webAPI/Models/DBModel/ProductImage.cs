using System;
using System.Collections.Generic;

namespace lesson11.webAPI.Models.DBModel;

public partial class ProductImage
{
    public int Id { get; set; }

    public int? Pid { get; set; }

    public string? Image { get; set; }
}
