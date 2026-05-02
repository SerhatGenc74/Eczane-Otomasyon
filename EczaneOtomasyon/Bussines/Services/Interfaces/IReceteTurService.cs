using EczaneOtomasyon.Domain.Entities;
using System.Collections.Generic;

namespace EczaneOtomasyon.Bussines.Services.Interfaces
{
    public interface IReceteTurService
    {
        Dictionary<int, string> GetReceteTurleri();
        List<ReceteTurleri> GetReceteTurList();
        bool ReceteTurEkle(ReceteTurleri tur);
        bool ReceteTurGuncelle(ReceteTurleri tur);
        bool ReceteTurSil(int turId);
    }
}
