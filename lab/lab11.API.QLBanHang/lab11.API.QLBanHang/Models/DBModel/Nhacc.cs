using System;
using System.Collections.Generic;

namespace lab11.API.QLBanHang.Models.DBModel;

public partial class Nhacc
{
    public string MaNcc { get; set; } = null!;

    public string? TenNcc { get; set; }

    public string? Diachi { get; set; }

    public string? Dienthoai { get; set; }

    public virtual ICollection<Dondh> Dondhs { get; set; } = new List<Dondh>();
}
