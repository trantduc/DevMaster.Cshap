using System;
using System.Collections.Generic;

namespace lesson11.webAPI.Models.DBModel;

public partial class ProductMaterial
{
    public int Id { get; set; }

    public int? Pid { get; set; }

    public int? Mid { get; set; }
}
