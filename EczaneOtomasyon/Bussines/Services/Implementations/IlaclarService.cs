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
        public IlaclarService(IUnitOfWork db)
        {
            _db = db;
        }

        public List<Ilaclar> IlacAra(string aramaKelimesi)
        {
            List<Ilaclar> list = _db.Ilaclar.GetByColumn(x => x.IlacAdi, $"%{aramaKelimesi}%", "LIKE");
            return list;
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
            // Satış/prescription detaylarında ilaç referansını kaldır (IlacID nullable)
            var satisDetaylar = _db.SatisDetay.GetByColumn(x => x.IlacID, ilacId);
            foreach (var det in satisDetaylar)
            {
                if (!_db.SatisDetay.Update(det.SatisDetayID, new { IlacID = (int?)null }))
                {
                    return false;
                }
            }

            var receteDetaylar = _db.ReceteDetay.GetByColumn(x => x.IlacID, ilacId);
            foreach (var det in receteDetaylar)
            {
                if (!_db.ReceteDetay.Update(det.DetayID, new { IlacID = (int?)null }))
                {
                    return false;
                }
            }

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
