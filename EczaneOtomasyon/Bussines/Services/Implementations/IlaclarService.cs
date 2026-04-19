using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Domain.Interfaces;
using EczaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Bussines.Services.Implementations
{
    public class IlaclarService : IIlaclarService
    {
        IUnitOfWork _db;
        IlaclarService(IUnitOfWork db)
        {
            _db = db;
        }

        public bool IlacEkle(Ilaclar ilac)
        {
            return _db.Ilaclar.Add(ilac);
        }

        public bool IlacGuncelle(Ilaclar ilac)
        {
            return _db.Ilaclar.Update(ilac.IlacID, ilac);
        }

        public bool IlacSil(int ilacId)
        {
            return _db.Ilaclar.Delete(ilacId);
        }

        public List<Ilaclar> KritikStoktakiIlaclariGetir()
        {
            var list = _db.Ilaclar.GetByColumn(x=> x.StokAdedi,x=>x.KritikSeviye,"<=");
            return list;
        }

        public List<Ilaclar> MiadiYaklasanIlaclariGetir(int kacGunKaldi = 30)
        {

            DateTime date = DateTime.Now.AddDays(kacGunKaldi);
            var list = _db.Ilaclar.GetByColumn(x=> x.SonKullanmaTarihi,date,"<=");
            return list;
        }

        public List<Ilaclar> TumIlaclariGetir()
        {
            return _db.Ilaclar.GetAll();
        }
    }
}
