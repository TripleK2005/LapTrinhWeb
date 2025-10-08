using System;
using System.Collections.Generic;

namespace Lab07DatabaseFirst.Models
{
    public partial class DmmonHoc
    {
        public DmmonHoc()
        {
            KetQuas = new HashSet<KetQua>();
        }

        public string MaMh { get; set; } = null!;
        public string TenMh { get; set; } = null!;
        public byte? SoTiet { get; set; }
        public string? GhiChu { get; set; }

        public virtual ICollection<KetQua> KetQuas { get; set; }
    }
}
