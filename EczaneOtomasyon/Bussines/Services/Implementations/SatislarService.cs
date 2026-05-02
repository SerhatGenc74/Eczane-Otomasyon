using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Domain.Interfaces;
using EczaneOtomasyon.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EczaneOtomasyon.Bussines.Services.Implementations
{
    public class SatislarService : ISatislarService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SatislarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Satislar> GetAllSatislar()
        {
            return _unitOfWork.Satislar.GetAll();
        }

        public Satislar GetSatisById(int satisId)
        {
            return _unitOfWork.Satislar.GetById(satisId);
        }

        public Satislar GetSatisByFaturaNo(string faturaNo)
        {
            return _unitOfWork.Satislar.GetByColumn(x => x.FaturaNo, faturaNo).FirstOrDefault();
        }

        public bool SatisEkle(Satislar satis)
        {
            if (satis == null)
            {
                return false;
            }

            return _unitOfWork.Satislar.Add(satis);
        }

        public bool SatisGuncelle(Satislar satis)
        {
            if (satis == null)
            {
                return false;
            }

            return _unitOfWork.Satislar.Update(satis.SatisID, satis);
        }

        public bool SatisSil(int satisId)
        {
            var detaylar = _unitOfWork.SatisDetay.GetAll().Where(x => x.SatisID == satisId).ToList();
            foreach (var detay in detaylar)
            {
                _unitOfWork.SatisDetay.Delete(detay.SatisDetayID);
            }

            return _unitOfWork.Satislar.Delete(satisId);
        }

        public List<SatisDetay> GetSatisDetaylari(int satisId)
        {
            return _unitOfWork.SatisDetay.GetAll().Where(x => x.SatisID == satisId).ToList();
        }

        public bool SatisDetayEkle(SatisDetay detay)
        {
            if (detay == null)
            {
                return false;
            }

            return _unitOfWork.SatisDetay.Add(detay);
        }

        public bool SatisDetaySil(int detayId)
        {
            return _unitOfWork.SatisDetay.Delete(detayId);
        }

        public bool CompleteSale(Satislar satis, List<SatisDetay> detaylar, out string errorMessage)
        {
            return _unitOfWork.Satislar.CompleteSale(satis, detaylar, out errorMessage);
        }
    }
}