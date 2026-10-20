using System;
using System.Collections.Generic;

namespace lab11.API.QLBanHang.Models.DBModel;

public partial class Pxuat
{
    public string SoPx { get; set; } = null!;

    public DateTime NgayXuat { get; set; }

    public string TenKh { get; set; } = null!;

    public virtual ICollection<Ctpxuat> Ctpxuats { get; set; } = new List<Ctpxuat>();
}
