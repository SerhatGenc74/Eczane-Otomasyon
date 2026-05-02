using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Bussines.Services.Interfaces
{
    public interface IServiceOfWork
    {
        IKategoriService KategoriService { get; }
        IReceteTurService ReceteTurService { get; }
        IIlaclarService IlaclarService { get; }
        IKullanicilarService KullanicilarService { get; }
        IDoktorlarService DoktorlarService { get; }
        IHastalarService HastalarService { get; }
        IRecetelerService RecetelerService { get; }
        ISatislarService SatislarService { get; }

    }
}
