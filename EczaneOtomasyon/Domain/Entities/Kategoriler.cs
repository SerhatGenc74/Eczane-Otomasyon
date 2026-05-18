using System.ComponentModel.DataAnnotations;

namespace EczaneOtomasyon.Domain.Entities
{
    public class Kategoriler
    {
        private int _kategoriID;
        private string _kategoriAdi;

        [Key]
        public int KategoriID
        {
            get { return _kategoriID; }
            set { _kategoriID = value; }
        }

        public string KategoriAdi
        {
            get { return _kategoriAdi; }
            set { _kategoriAdi = value; }
        }
    }
}
