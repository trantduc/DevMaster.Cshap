using System;
using System.Collections.Generic;

namespace lab11.API.QLBanHang.Models.DBModel;

public partial class Ctdondh
{
    public string SoDh { get; set; } = null!;

    public string Mavtu { get; set; } = null!;

    public int? SlDat { get; set; }

    public virtual Vattu MavtuNavigation { get; set; } = null!;

    public virtual Dondh SoDhNavigation { get; set; } = null!;
}
