using System.ComponentModel.DataAnnotations;


namespace TEST02.Models
{
    
    public class NhaCungCap
    {
        [Key]
        public int MaNhaCungCap {get; set; }
        public string TenNhaCungCap {get; set; }
        
    }
}