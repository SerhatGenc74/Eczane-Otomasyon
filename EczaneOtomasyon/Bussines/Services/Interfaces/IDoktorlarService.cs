using EczaneOtomasyon.Models;
using System.Collections.Generic;

namespace EczaneOtomasyon.Bussines.Services.Interfaces
{
    public interface IDoktorlarService
    {
        Dictionary<int, string> GetDoktorlar();
        List<Doktorlar> GetDoktorList();
        bool DoktorEkle(Doktorlar doktor);
        bool DoktorGuncelle(Doktorlar doktor);
        bool DoktorSil(int doktorId);
    }
}