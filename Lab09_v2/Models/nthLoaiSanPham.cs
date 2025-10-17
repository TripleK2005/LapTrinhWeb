using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab09_v2.Models
{
    [Table("nth_LoaiSanPham")]
    public class nthLoaiSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long nthId { get; set; }

        [Required]
        [Display(Name = "Mã Loại")]
        public string nthMaLoai { get; set; }

        [Required]
        [Display(Name = "Tên Loại")]
        public string nthTenLoai { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool nthTrangThai { get; set; }

        [ValidateNever]
        public virtual ICollection<nthSanPham> SanPhams { get; set; }

    }
}