using System;
using System.Collections.Generic;

namespace lab11.API.QLBanHang.Models.DBModel;

public partial class Ctpxuat
{
    public string SoPx { get; set; } = null!;

    public string Mavtu { get; set; } = null!;

    public int? Slxuat { get; set; }

    public decimal? Dgxuat { get; set; }

    public virtual Vattu MavtuNavigation { get; set; } = null!;

    public virtual Pxuat SoPxNavigation { get; set; } = null!;
}
