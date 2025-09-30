using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab06Validation.Models
{
    public enum Branch { IT, BE, CE, EE }
    public enum Gender { Nam, Nữ, Khác }

    public class Student : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ tên bắt buộc nhập")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải từ 4 đến 100 ký tự")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email bắt buộc nhập")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email phải có đuôi @gmail.com")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu bắt buộc nhập")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu ít nhất 8 ký tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
            ErrorMessage = "Mật khẩu phải có chữ hoa, chữ thường, số và ký tự đặc biệt")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Ngành học bắt buộc chọn")]
        public Branch? Branch { get; set; }

        [Required(ErrorMessage = "Giới tính bắt buộc chọn")]
        public Gender? Gender { get; set; }

        public bool IsRegular { get; set; }

        [Required(ErrorMessage = "Địa chỉ bắt buộc nhập")]
        public string? Address { get; set; }

        // nullable để binding không vỡ khi chưa nhập
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Điểm bắt buộc nhập")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải từ 0.0 đến 10.0")]
        public double? Score { get; set; }

        // Server-side validation tập trung cho ngày sinh (không phụ thuộc culture)
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // DateOfBirth required check (nếu muốn giữ Required attribute, có thể bỏ dòng này)
            if (!DateOfBirth.HasValue)
            {
                yield return new ValidationResult("Ngày sinh bắt buộc nhập", new[] { nameof(DateOfBirth) });
            }
            else
            {
                var min = new DateTime(1963, 1, 1);
                var max = new DateTime(2005, 12, 31);
                if (DateOfBirth.Value < min || DateOfBirth.Value > max)
                {
                    yield return new ValidationResult("Ngày sinh từ 01/01/1963 đến 31/12/2005", new[] { nameof(DateOfBirth) });
                }
            }

            // (Có thể thêm validate chung khác ở đây nếu cần)
            yield break;
        }
    }
}
