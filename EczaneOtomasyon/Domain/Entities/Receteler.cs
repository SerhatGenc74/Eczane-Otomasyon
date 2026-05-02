using System;
using System.ComponentModel.DataAnnotations;

namespace EczaneOtomasyon.Models
{
    public class Receteler
    {
        [Key]
        public int ReceteID { get; set; }
        public string ReceteKodu { get; set; }
        public int? HastaID { get; set; }
        public int? DoktorID { get; set; }
        public int? ReceteTipiID { get; set; }
        public DateTime Tarih { get; set; }
        public bool Durum { get; set; }
    }
}