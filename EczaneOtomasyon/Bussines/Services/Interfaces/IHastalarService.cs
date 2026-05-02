using EczaneOtomasyon.Models;
using System.Collections.Generic;

namespace EczaneOtomasyon.Bussines.Services.Interfaces
{
    public interface IHastalarService
    {
        List<Hastalar> GetAllHastalar();
        Hastalar GetHastaById(int hastaId);
        List<Hastalar> HastaAra(string arama);
        bool HastaEkle(Hastalar hasta);
        bool HastaGuncelle(Hastalar hasta);
        bool HastaSil(int hastaId);
    }
}