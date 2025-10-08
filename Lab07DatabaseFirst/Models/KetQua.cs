using System;
using System.Collections.Generic;

namespace Lab07DatabaseFirst.Models
{
    public partial class KetQua
    {
        public string MaSv { get; set; } = null!;
        public string MaMh { get; set; } = null!;
        public byte LanThi { get; set; }
        public decimal? Diem { get; set; }

        public virtual DmmonHoc MaMhNavigation { get; set; } = null!;
        public virtual DssinhVien MaSvNavigation { get; set; } = null!;
    }
}
