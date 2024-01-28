using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Electronic.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        [Column("role_id")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Tên role là bắt buộc.")]
        [StringLength(45, ErrorMessage = "Tên người dùng không được vượt quá 45 ký tự.")]
        public string Name { get; set; } = "";

        public ICollection<User> Users { get; set; }
    }
}
