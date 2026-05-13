using System;
using System.ComponentModel.DataAnnotations;
namespace EczaneOtomasyon.Models
{
    public class Ilaclar : BaseEntity
    {
        [Key]
        public int IlacID { get; set; }
        public string IlacAdi { get; set; }
        public int KategoriID { get; set; }
        public int TurID { get; set; }
        public decimal BirimFiyat { get; set; }
        public int StokAdedi { get; set; }
        public int KritikSeviye { get; set; }
        public DateTime SonKullanmaTarihi { get; set; }
        public string RafNo { get; set; }
        public override string OzetBilgiVer()
        {
            return $"İlaç Adı: {this.IlacAdi} - Stok Durumu: {this.StokAdedi} adet mevcuttur.";
        }
    }


}