using System.ComponentModel.DataAnnotations;

namespace EczaneOtomasyon.Models
{
    public class Kullanicilar
    {
        [Key]
        public int KullaniciID { get; set; }
        public string AdSoyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Rol { get; set; }
    }
}