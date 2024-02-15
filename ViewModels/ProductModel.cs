using System.ComponentModel.DataAnnotations;

namespace API_Electronic.ViewModels
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
        [StringLength(45, ErrorMessage = "Tên sản phẩm không được vượt quá 45 ký tự.")]
        public string ProductName { get; set; } = "";

        [Required(ErrorMessage = "Giá sản phẩm là bắt buộc.")]
        public decimal Price { get; set; }
        public int quantity { get; set; }

        [StringLength(45, ErrorMessage = "Ghi chú không được vượt quá 45 ký tự.")]
        public string? Note { get; set; }
    }
}
