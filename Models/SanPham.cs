using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST02.Models
{
    public class SanPham
    {
        [Key]
         public int MaNhaCungCap { get; set; }
        [ForeignKey("MaNhaCungCap")]
        public NhaCungCap? NhaCungCap { get; set; }
        public string MaSanPham { get; set; }
       
        public string TenSanPham { get; set; }
       
    }
}
