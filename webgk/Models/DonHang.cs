using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webgk.Models
{
    public class DonHang
    {
        [Key]
        public int MaDon { get; set; }

        [Required(ErrorMessage = "Khách hàng là bắt buộc.")]
        public string MaKhach { get; set; }

        [Required(ErrorMessage = "Sản phẩm là bắt buộc.")]
        public int ID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TongTien { get; set; }

        [Required]
        public string TrangThaiDH { get; set; }

        [Required]
        public DateTime NgayBan { get; set; }


    }
}
