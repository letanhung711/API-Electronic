using System.ComponentModel.DataAnnotations;

namespace API_Electronic.ViewModels
{
    public class RoleModel
    {
        [Required(ErrorMessage = "Tên role là bắt buộc.")]
        [StringLength(45, ErrorMessage = "Tên người dùng không được vượt quá 45 ký tự.")]
        public string Name { get; set; } = "";
    }
}
