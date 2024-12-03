using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webgk.Models
{
    public class sanpham
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string TenSP { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal GiaNhap { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal GiaBan { get; set; }

        [Required]
        public int Soluong { get; set; }

        [Required]
        public string LoaiSP { get; set; }
    }
}
