using System;
using System.Collections.Generic;

namespace Lab07DatabaseFirst.Models
{
    public partial class Dmkhoa
    {
        public Dmkhoa()
        {
            DssinhViens = new HashSet<DssinhVien>();
        }

        public string MaKhoa { get; set; } = null!;
        public string TenKhoa { get; set; } = null!;

        public virtual ICollection<DssinhVien> DssinhViens { get; set; }
    }
}
