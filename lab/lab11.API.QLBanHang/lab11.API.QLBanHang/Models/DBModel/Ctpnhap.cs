using System;
using System.Collections.Generic;

namespace lab11.API.QLBanHang.Models.DBModel;

public partial class Ctpnhap
{
    public string SoPn { get; set; } = null!;

    public string Mavtu { get; set; } = null!;

    public int? Slnhap { get; set; }

    public decimal? Dgnhap { get; set; }

    public virtual Vattu MavtuNavigation { get; set; } = null!;

    public virtual Pnhap SoPnNavigation { get; set; } = null!;
}
