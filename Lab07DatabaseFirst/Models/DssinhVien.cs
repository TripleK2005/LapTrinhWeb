using System;
using System.Collections.Generic;

namespace Lab07DatabaseFirst.Models
{
    public partial class DssinhVien
    {
        public DssinhVien()
        {
            KetQuas = new HashSet<KetQua>();
        }

        public string MaSv { get; set; } = null!;
        public string HoSv { get; set; } = null!;
        public string TenSv { get; set; } = null!;
        public string? Phai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? NoiSinh { get; set; }
        public string? MaKhoa { get; set; }
        public double? HocBong { get; set; }

        public virtual Dmkhoa? MaKhoaNavigation { get; set; }
        public virtual ICollection<KetQua> KetQuas { get; set; }
    }
}
