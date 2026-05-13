using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Domain.Entities;
using EczaneOtomasyon.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EczaneOtomasyon.Bussines.Services.Implementations
{
    public class ReceteTurService : IReceteTurService
    {
        IUnitOfWork _unitOfWork;
        public ReceteTurService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Dictionary<int, string> GetReceteTurleri()
        {
            var receteturleri = _unitOfWork.ReceteTur.GetAll();
            return receteturleri.ToDictionary(rt=>rt.TurID, rt=>rt.TurAdi);
        }

        public List<ReceteTurleri> GetReceteTurList()
        {
            return _unitOfWork.ReceteTur.GetAll();
        }

        public bool ReceteTurEkle(ReceteTurleri tur)
        {
            if (tur == null)
            {
                return false;
            }

            return _unitOfWork.ReceteTur.Add(tur);
        }

        public bool ReceteTurGuncelle(ReceteTurleri tur)
        {
            if (tur == null)
            {
                return false;
            }

            return _unitOfWork.ReceteTur.Update(tur.TurID, tur);
        }

        public bool ReceteTurSil(int turId)
        {
            var receteler = _unitOfWork.Receteler.GetByColumn(x => x.ReceteTipiID, turId);
            foreach (var recete in receteler)
            {
                if (!_unitOfWork.Receteler.Update(recete.ReceteID, new { ReceteTipiID = (int?)null }))
                {
                    return false;
                }
            }

            return _unitOfWork.ReceteTur.Delete(turId);
        }
    }
}
