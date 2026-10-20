using System;
using System.Collections.Generic;

namespace lab11.API.QLBanHang.Models.DBModel;

public partial class Tonkho
{
    public string NamThang { get; set; } = null!;

    public string Mavtu { get; set; } = null!;

    public int? Sldau { get; set; }

    public int? TongSln { get; set; }

    public int? TongSlx { get; set; }

    public int? Slcuoi { get; set; }

    public virtual Vattu MavtuNavigation { get; set; } = null!;
}
