using System.ComponentModel.DataAnnotations;

namespace EczaneOtomasyon.Models
{
    public class SatisDetay
    {
        [Key]
        public int SatisDetayID { get; set; }
        public int? SatisID { get; set; }
        public int? IlacID { get; set; }
        public int Adet { get; set; }
        public decimal SatisBirimFiyati { get; set; }
        public decimal AraToplam { get; set; }
    }
}