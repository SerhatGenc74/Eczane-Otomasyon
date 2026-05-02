using EczaneOtomasyon.Bussines.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Bussines.Services
{
    public class ServiceOfWork : IServiceOfWork
    {
        public ServiceOfWork(IKategoriService kategoriService, IReceteTurService receteTurService, IIlaclarService ilaclarService, IKullanicilarService kullanicilarService, IDoktorlarService doktorlarService, IHastalarService hastalarService, IRecetelerService recetelerService, ISatislarService satislarService)
        {
            KategoriService = kategoriService ?? throw new ArgumentNullException(nameof(kategoriService));
            ReceteTurService = receteTurService ?? throw new ArgumentNullException(nameof(receteTurService));
            IlaclarService = ilaclarService ?? throw new ArgumentNullException(nameof(ilaclarService));
            KullanicilarService = kullanicilarService ?? throw new ArgumentNullException(nameof(kullanicilarService));
            DoktorlarService = doktorlarService ?? throw new ArgumentNullException(nameof(doktorlarService));
            HastalarService = hastalarService ?? throw new ArgumentNullException(nameof(hastalarService));
            RecetelerService = recetelerService ?? throw new ArgumentNullException(nameof(recetelerService));
            SatislarService = satislarService ?? throw new ArgumentNullException(nameof(satislarService));
        }

        public IKategoriService KategoriService { get; }

        public IReceteTurService ReceteTurService { get; }

        public IIlaclarService IlaclarService { get; }

        public IKullanicilarService KullanicilarService { get; }

        public IDoktorlarService DoktorlarService { get; }

        public IHastalarService HastalarService { get; }

        public IRecetelerService RecetelerService { get; }

        public ISatislarService SatislarService { get; }
    }
}
