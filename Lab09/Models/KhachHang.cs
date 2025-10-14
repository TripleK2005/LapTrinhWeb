using System;
using System.Collections.Generic;

namespace Lab09.Models;

public partial class KhachHang
{
    public int Id { get; set; }

    public string MaKhachHang { get; set; } = null!;

    public string HoTenKhachHang { get; set; } = null!;

    public string? Email { get; set; }

    public string? MatKhau { get; set; }

    public string? DienThoai { get; set; }

    public string? DiaChi { get; set; }

    public DateOnly? NgayDangKy { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
