using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Electronic.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
        [StringLength(45, ErrorMessage = "Tên sản phẩm không được vượt quá 45 ký tự.")]
        public string ProductName { get; set; } = "";

        [Required(ErrorMessage = "Giá sản phẩm là bắt buộc.")]
        public decimal Price { get; set; }
        public int quantity { get; set; }

        [StringLength(45, ErrorMessage = "Ghi chú không được vượt quá 45 ký tự.")]
        public string? Note { get; set; }

        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "Ngày tạo không hợp lệ.")]
        public DateTime Create_Time { get; set; }

        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "Ngày cập nhật không hợp lệ.")]
        public DateTime Update_Time { get; set; }

        public Product()
        {
            // Khởi tạo giá trị mặc định cho các thuộc tính Create_Time và Update_Time
            Create_Time = DateTime.Now;
            Update_Time = DateTime.Now;
        }
    }
}
