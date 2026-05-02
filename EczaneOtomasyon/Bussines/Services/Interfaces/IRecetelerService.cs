using EczaneOtomasyon.Models;
using System.Collections.Generic;

namespace EczaneOtomasyon.Bussines.Services.Interfaces
{
    public interface IRecetelerService
    {
        List<Receteler> GetAllReceteler();
        Receteler GetReceteById(int receteId);
        bool ReceteEkle(Receteler recete);
        bool ReceteGuncelle(Receteler recete);
        bool ReceteSil(int receteId);
        List<ReceteDetay> GetReceteDetaylari(int receteId);
        bool ReceteDetayEkle(ReceteDetay detay);
        bool ReceteDetaySil(int detayId);
    }
}