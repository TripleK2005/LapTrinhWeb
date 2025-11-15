//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_12_lab1.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tên")]
        [Length(4, maximumLength: 100, ErrorMessage = "phải 4 ký tự tối đa 100")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email không được trống")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[gG][mM][aA][iI][lL]\.[cC][oO][mM]$", ErrorMessage = "Email phải có đuôi là @gmail.com")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$", ErrorMessage = "Mật khẩu phải gồm chữ cái thường, in hoa, số và ký tự đặc biệt")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Bạn chưa chọn Branch")]
        public Branch? Branch { get; set; }
        [Required(ErrorMessage = "Bạn chưa chọn giới tính")]
        public Gender? Gender { get; set; }
        public bool IsRegular { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập năm sinh")]
        [Range(typeof(DateTime), "1/1/1950", "31/12/2025", ErrorMessage = "Năm sinh phải từ 1/1/1950 đến 31/12/2025")]
        [DataType(DataType.Date, ErrorMessage = "Nhập năm sinh không đúng")]
        public DateTime? DateOfBorth { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập điểm")]
        [Range(0, 10, ErrorMessage = "Điểm phải từ 0 đến 10")]
        public int? Diem { get; set; }
        public string? ProfileImagePath { get; set; }
        [NotMapped]
        public IFormFile? ProfileImage { get; set; }
    }
}
