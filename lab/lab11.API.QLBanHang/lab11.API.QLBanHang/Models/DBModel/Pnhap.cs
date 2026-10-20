using System;
using System.Collections.Generic;

namespace lab11.API.QLBanHang.Models.DBModel;

public partial class Pnhap
{
    public string SoPn { get; set; } = null!;

    public DateTime NgayNhap { get; set; }

    public string SoDh { get; set; } = null!;

    public virtual ICollection<Ctpnhap> Ctpnhaps { get; set; } = new List<Ctpnhap>();
}
