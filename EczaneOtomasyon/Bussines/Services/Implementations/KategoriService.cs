using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Domain.Entities;
using EczaneOtomasyon.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EczaneOtomasyon.Bussines.Services.Implementations
{
    public class KategoriService : IKategoriService
    {
        IUnitOfWork _unitOfWork;
        public KategoriService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Dictionary<int, string> GetAllKategori()
        {
            var kategoriler = _unitOfWork.Kategori.GetAll();
            return kategoriler.ToDictionary(k => k.KategoriID, k => k.KategoriAdi);
        }

        public List<Kategoriler> GetKategoriList()
        {
            return _unitOfWork.Kategori.GetAll();
        }

        public bool KategoriEkle(Kategoriler kategori)
        {
            if (kategori == null)
            {
                return false;
            }

            return _unitOfWork.Kategori.Add(kategori);
        }

        public bool KategoriGuncelle(Kategoriler kategori)
        {
            if (kategori == null)
            {
                return false;
            }

            return _unitOfWork.Kategori.Update(kategori.KategoriID, kategori);
        }

        public bool KategoriSil(int kategoriId)
        {
            return _unitOfWork.Kategori.Delete(kategoriId);
        }
    }
}
