using System;
using System.Collections.Generic;

namespace Lab09.Models;

public partial class SanPham
{
    public int Id { get; set; }

    public string MaSanPham { get; set; } = null!;

    public string TenSanPham { get; set; } = null!;

    public string? HinhAnh { get; set; }

    public int? SoLuong { get; set; }

    public decimal? DonGia { get; set; }

    public int MaLoai { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<CtHoaDon> CtHoaDons { get; set; } = new List<CtHoaDon>();

    public virtual LoaiSanPham MaLoaiNavigation { get; set; } = null!;
}
