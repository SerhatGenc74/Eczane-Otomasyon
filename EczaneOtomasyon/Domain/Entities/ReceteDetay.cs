using System.ComponentModel.DataAnnotations;

namespace EczaneOtomasyon.Models
{
    public class ReceteDetay
    {
        [Key]
        public int DetayID { get; set; }
        public int? ReceteID { get; set; }
        public int? IlacID { get; set; }
        public string KullanimSekli { get; set; }
        public int Adet { get; set; }
    }
}