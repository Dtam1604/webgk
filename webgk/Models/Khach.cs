using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webgk.Models
{
    public class Khach
    {
        [Key]
        public string MaKhach { get; set; }  // Mã khách
        [Required]
        public string TenKhach { get; set; }        // Tên khách hàng
        public string DiaChi { get; set; }     // Địa chỉ
        public string SDT { get; set; } // Số điện thoại (SDT)
        public string Email {  get; set; }
    }
}
