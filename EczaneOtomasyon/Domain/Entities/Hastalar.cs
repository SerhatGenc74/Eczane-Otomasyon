using System.ComponentModel.DataAnnotations;

namespace EczaneOtomasyon.Models
{
    public class Hastalar
    {
        [Key]
        public int HastaID { get; set; }
        public string TCKimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Cinsiyet { get; set; }
        public string KanGrubu { get; set; }
        public string AlerjiBilgisi { get; set; }
    }
}