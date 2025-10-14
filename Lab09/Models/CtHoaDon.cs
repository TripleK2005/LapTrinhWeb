using System;
using System.Collections.Generic;

namespace Lab09.Models;

public partial class CtHoaDon
{
    public int Id { get; set; }

    public int HoaDonId { get; set; }

    public int SanPhamId { get; set; }

    public int? SoLuongMua { get; set; }

    public decimal? DonGiaMua { get; set; }

    public decimal? ThanhTien { get; set; }

    public bool? TrangThai { get; set; }

    public virtual HoaDon HoaDon { get; set; } = null!;

    public virtual SanPham SanPham { get; set; } = null!;
}
