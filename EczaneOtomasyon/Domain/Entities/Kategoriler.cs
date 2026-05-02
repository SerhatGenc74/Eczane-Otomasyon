using System.ComponentModel.DataAnnotations;

namespace EczaneOtomasyon.Domain.Entities
{
    public class Kategoriler
    {
        [Key]
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }
    }
}
