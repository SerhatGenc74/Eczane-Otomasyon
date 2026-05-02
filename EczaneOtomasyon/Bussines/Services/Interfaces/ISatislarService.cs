using EczaneOtomasyon.Models;
using System.Collections.Generic;

namespace EczaneOtomasyon.Bussines.Services.Interfaces
{
    public interface ISatislarService
    {
        List<Satislar> GetAllSatislar();
        Satislar GetSatisById(int satisId);
        Satislar GetSatisByFaturaNo(string faturaNo);
        bool SatisEkle(Satislar satis);
        bool CompleteSale(Satislar satis, List<SatisDetay> detaylar, out string errorMessage);
        bool SatisGuncelle(Satislar satis);
        bool SatisSil(int satisId);
        List<SatisDetay> GetSatisDetaylari(int satisId);
        bool SatisDetayEkle(SatisDetay detay);
        bool SatisDetaySil(int detayId);
    }
}