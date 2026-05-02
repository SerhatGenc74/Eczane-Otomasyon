using EczaneOtomasyon.Models;
using System.Collections.Generic;

namespace EczaneOtomasyon.Domain.Interfaces
{
    public interface ISatislarRepository : IRepositoryBase<Satislar>
    {
        bool CompleteSale(Satislar satis, List<SatisDetay> detaylar, out string errorMessage);
    }
}