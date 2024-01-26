using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Electronic.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Tên người dùng là bắt buộc.")]
        [StringLength(45, ErrorMessage = "Tên người dùng không được vượt quá 45 ký tự.")]
        public string UserName { get; set; } = "";

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        [DataType(DataType.Password)]
        [StringLength(150, ErrorMessage = "Mật khẩu phải dài ít nhất {6} ký tự.", MinimumLength = 6)]
        public string Password { get; set; } = "";

        [StringLength(50, ErrorMessage = "Họ và tên không được vượt quá 50 ký tự.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; } = "";

        [StringLength(20, ErrorMessage = "Số điện thoại không được vượt quá 20 ký tự.")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string? PhoneNumber { get; set; }

        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "Ngày sinh không hợp lệ.")]
        public DateTime BirthDate { get; set; }

        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "Ngày tạo không hợp lệ.")]
        public DateTime Create_Time { get; set; }
    }
}
