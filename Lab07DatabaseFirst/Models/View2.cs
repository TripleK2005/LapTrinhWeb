using System;
using System.Collections.Generic;

namespace Lab07DatabaseFirst.Models
{
    public partial class View2
    {
        public string HoSv { get; set; } = null!;
        public string TenSv { get; set; } = null!;
        public string? MaKhoa { get; set; }
        public string? NoiSinh { get; set; }
        public double? HocBong { get; set; }
    }
}
