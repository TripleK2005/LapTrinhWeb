using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab09_v2.Models
{
    [Table("nth_SanPham")]
    public class nthSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long nthId { get; set; }

        [Required]
        [Display(Name = "Mã Sản Phẩm")]
        public string nthMaSanPham { get; set; }

        [Required]
        [Display(Name = "Tên Sản Phẩm")]
        public string nthTenSanPham { get; set; }

        [Display(Name = "Hình Ảnh")]
        public string nthHinhAnh { get; set; }

        [Display(Name = "Số Lượng")]
        public int nthSoLuong { get; set; }

        [Display(Name = "Đơn Giá")]
        public decimal nthDonGia { get; set; }

        public long nthLoaiId { get; set; }

        [ForeignKey("nthLoaiId")]
        [ValidateNever]
        public virtual nthLoaiSanPham LoaiSanPham { get; set; }

    }
}