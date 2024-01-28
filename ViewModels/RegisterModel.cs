using System.ComponentModel.DataAnnotations;

namespace API_Electronic.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Tên người dùng là bắt buộc.")]
        [StringLength(45, ErrorMessage = "Tên người dùng không được vượt quá 45 ký tự.")]
        public string UserName { get; set; } = "";

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        [DataType(DataType.Password)]
        [StringLength(45, ErrorMessage = "Mật khẩu phải dài ít nhất {6} ký tự.", MinimumLength = 6)]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; } = "";

        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "Ngày sinh không hợp lệ.")]
        public DateTime BirthDate { get; set; }

        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "Ngày tạo không hợp lệ.")]
        public DateTime Create_Time { get; set; }
    }
}
