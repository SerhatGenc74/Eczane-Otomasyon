using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Domain.Interfaces;
using EczaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EczaneOtomasyon.Bussines.Services.Implementations
{
    public class HastalarService : IHastalarService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HastalarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Hastalar> GetAllHastalar()
        {
            return _unitOfWork.Hastalar.GetAll();
        }

        public Hastalar GetHastaById(int hastaId)
        {
            return _unitOfWork.Hastalar.GetById(hastaId);
        }

        public List<Hastalar> HastaAra(string arama)
        {
            if (string.IsNullOrWhiteSpace(arama))
            {
                return GetAllHastalar();
            }

            arama = arama.Trim();
            return _unitOfWork.Hastalar.GetAll()
                .Where(h => (h.Ad != null && h.Ad.IndexOf(arama, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (h.Soyad != null && h.Soyad.IndexOf(arama, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (h.TCKimlikNo != null && h.TCKimlikNo.IndexOf(arama, StringComparison.OrdinalIgnoreCase) >= 0))
                .ToList();
        }

        public bool HastaEkle(Hastalar hasta)
        {
            if (hasta == null)
            {
                return false;
            }

            return _unitOfWork.Hastalar.Add(hasta);
        }

        public bool HastaGuncelle(Hastalar hasta)
        {
            if (hasta == null)
            {
                return false;
            }

            return _unitOfWork.Hastalar.Update(hasta.HastaID, hasta);
        }

        public bool HastaSil(int hastaId)
        {
            return _unitOfWork.Hastalar.Delete(hastaId);
        }
    }
}