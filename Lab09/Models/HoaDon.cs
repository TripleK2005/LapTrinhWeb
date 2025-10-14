using System;
using System.Collections.Generic;

namespace Lab09.Models;

public partial class HoaDon
{
    public int Id { get; set; }

    public string MaHoaDon { get; set; } = null!;

    public int MaKhachHang { get; set; }

    public DateOnly? NgayHoaDon { get; set; }

    public DateOnly? NgayNhan { get; set; }

    public string? HoTenKhachHang { get; set; }

    public string? Email { get; set; }

    public string? DienThoai { get; set; }

    public string? DiaChi { get; set; }

    public decimal? TongTriGia { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<CtHoaDon> CtHoaDons { get; set; } = new List<CtHoaDon>();

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;
}
