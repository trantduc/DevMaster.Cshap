using System;
using System.Collections.Generic;

namespace lab11.API.QLBanHang.Models.DBModel;

public partial class VwGetAll
{
    public string SoPn { get; set; } = null!;

    public DateTime NgayNhap { get; set; }

    public int? Slnhap { get; set; }

    public decimal? Dgnhap { get; set; }

    public decimal? ThanhTien { get; set; }

    public string? TenVtu { get; set; }
}
