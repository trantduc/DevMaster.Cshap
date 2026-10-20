using System;
using System.Collections.Generic;

namespace lab11.API.QLBanHang.Models.DBModel;

public partial class Vattu
{
    public string Mavtu { get; set; } = null!;

    public string? TenVtu { get; set; }

    public string? Dvtinh { get; set; }

    public float? Phantram { get; set; }

    public virtual ICollection<Ctdondh> Ctdondhs { get; set; } = new List<Ctdondh>();

    public virtual ICollection<Ctpnhap> Ctpnhaps { get; set; } = new List<Ctpnhap>();

    public virtual ICollection<Ctpxuat> Ctpxuats { get; set; } = new List<Ctpxuat>();

    public virtual ICollection<Tonkho> Tonkhos { get; set; } = new List<Tonkho>();
}
