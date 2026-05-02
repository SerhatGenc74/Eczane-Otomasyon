using System.ComponentModel.DataAnnotations;

namespace EczaneOtomasyon.Domain.Entities
{
    public class ReceteTurleri
    {
        [Key]
        public int TurID { get; set; }
        public string TurAdi { get; set; }
    }
}
