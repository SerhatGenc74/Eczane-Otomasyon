using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Domain.Interfaces;
using EczaneOtomasyon.Models;
using System.Collections.Generic;
using System.Linq;

namespace EczaneOtomasyon.Bussines.Services.Implementations
{
    public class DoktorlarService : IDoktorlarService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoktorlarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Dictionary<int, string> GetDoktorlar()
        {
            var doktorlar = _unitOfWork.Doktorlar.GetAll();
            return doktorlar.ToDictionary(d => d.DoktorID, d => d.Ad_Soyad);
        }

        public List<Doktorlar> GetDoktorList()
        {
            return _unitOfWork.Doktorlar.GetAll();
        }

        public bool DoktorEkle(Doktorlar doktor)
        {
            if (doktor == null)
            {
                return false;
            }

            return _unitOfWork.Doktorlar.Add(doktor);
        }

        public bool DoktorGuncelle(Doktorlar doktor)
        {
            if (doktor == null)
            {
                return false;
            }

            return _unitOfWork.Doktorlar.Update(doktor.DoktorID, doktor);
        }

        public bool DoktorSil(int doktorId)
        {
            var receteler = _unitOfWork.Receteler.GetByColumn(x => x.DoktorID, doktorId);
            foreach (var recete in receteler)
            {
                if (!_unitOfWork.Receteler.Update(recete.ReceteID, new { DoktorID = (int?)null }))
                {
                    return false;
                }
            }

            return _unitOfWork.Doktorlar.Delete(doktorId);
        }
    }
}