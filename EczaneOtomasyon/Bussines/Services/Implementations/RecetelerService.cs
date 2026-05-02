using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Domain.Interfaces;
using EczaneOtomasyon.Models;
using System.Collections.Generic;
using System.Linq;

namespace EczaneOtomasyon.Bussines.Services.Implementations
{
    public class RecetelerService : IRecetelerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecetelerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Receteler> GetAllReceteler()
        {
            return _unitOfWork.Receteler.GetAll();
        }

        public Receteler GetReceteById(int receteId)
        {
            return _unitOfWork.Receteler.GetById(receteId);
        }

        public bool ReceteEkle(Receteler recete)
        {
            if (recete == null)
            {
                return false;
            }

            return _unitOfWork.Receteler.Add(recete);
        }

        public bool ReceteGuncelle(Receteler recete)
        {
            if (recete == null)
            {
                return false;
            }

            return _unitOfWork.Receteler.Update(recete.ReceteID, recete);
        }

        public bool ReceteSil(int receteId)
        {
            return _unitOfWork.Receteler.Delete(receteId);
        }

        public List<ReceteDetay> GetReceteDetaylari(int receteId)
        {
            return _unitOfWork.ReceteDetay.GetAll().Where(x => x.ReceteID == receteId).ToList();
        }

        public bool ReceteDetayEkle(ReceteDetay detay)
        {
            if (detay == null)
            {
                return false;
            }

            return _unitOfWork.ReceteDetay.Add(detay);
        }

        public bool ReceteDetaySil(int detayId)
        {
            return _unitOfWork.ReceteDetay.Delete(detayId);
        }
    }
}