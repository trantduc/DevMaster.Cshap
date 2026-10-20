using System;
using System.Collections.Generic;

namespace lab11.API.QLBanHang.Models.DBModel;

public partial class Dondh
{
    public string SoDh { get; set; } = null!;

    public DateTime? NgayDh { get; set; }

    public string MaNcc { get; set; } = null!;

    public virtual ICollection<Ctdondh> Ctdondhs { get; set; } = new List<Ctdondh>();

    public virtual Nhacc MaNccNavigation { get; set; } = null!;
}
