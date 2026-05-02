using System.ComponentModel.DataAnnotations;

namespace EczaneOtomasyon.Models
{
    public class Doktorlar
    {
        [Key]
        public int DoktorID { get; set; }
        public string Ad_Soyad { get; set; }
        public string Brans { get; set; }
        public string CalistigiKurum { get; set; }
    }
}