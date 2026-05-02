using EczaneOtomasyon.Domain.Entities;
using System.Collections.Generic;

namespace EczaneOtomasyon.Bussines.Services.Interfaces
{
    public interface IKategoriService
    {
        Dictionary<int, string> GetAllKategori();
        List<Kategoriler> GetKategoriList();
        bool KategoriEkle(Kategoriler kategori);
        bool KategoriGuncelle(Kategoriler kategori);
        bool KategoriSil(int kategoriId);
    }
}
