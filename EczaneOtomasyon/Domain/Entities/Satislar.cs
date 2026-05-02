using System;
using System.ComponentModel.DataAnnotations;

namespace EczaneOtomasyon.Models
{
    public class Satislar
    {
        [Key]
        public int SatisID { get; set; }
        public string FaturaNo { get; set; }
        public DateTime Tarih { get; set; }
        public string SatisTuru { get; set; }
        public int? ReceteID { get; set; }
        public decimal ToplamTutar { get; set; }
        public decimal IndirimTutari { get; set; }
        public string OdemeYontemi { get; set; }
        public int? KullaniciID { get; set; }
    }
}