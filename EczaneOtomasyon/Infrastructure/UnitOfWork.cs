using EczaneOtomasyon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IIlaclarRepository ilaclar,
                          IKullanicilarRepository kullanicilar,
                          IKategoriRepository kategori,
                          IReceteTurRepository receteTur,
                          IDoktorlarRepository doktorlar,
                          IHastalarRepository hastalar,
                          IRecetelerRepository receteler,
                          IReceteDetayRepository receteDetay,
                          ISatislarRepository satislar,
                          ISatisDetayRepository satisDetay)
        {
            Ilaclar = ilaclar ?? throw new ArgumentNullException(nameof(ilaclar));
            Kullanicilar = kullanicilar ?? throw new ArgumentNullException(nameof(kullanicilar));
            Kategori = kategori ?? throw new ArgumentNullException(nameof(kategori));
            ReceteTur = receteTur ?? throw new ArgumentNullException(nameof(receteTur));
            Doktorlar = doktorlar ?? throw new ArgumentNullException(nameof(doktorlar));
            Hastalar = hastalar ?? throw new ArgumentNullException(nameof(hastalar));
            Receteler = receteler ?? throw new ArgumentNullException(nameof(receteler));
            ReceteDetay = receteDetay ?? throw new ArgumentNullException(nameof(receteDetay));
            Satislar = satislar ?? throw new ArgumentNullException(nameof(satislar));
            SatisDetay = satisDetay ?? throw new ArgumentNullException(nameof(satisDetay));
        }

        public IIlaclarRepository Ilaclar { get; }
        public IKullanicilarRepository Kullanicilar { get; }

        public IKategoriRepository Kategori { get; }

        public IReceteTurRepository ReceteTur { get; }

        public IDoktorlarRepository Doktorlar { get; }

        public IHastalarRepository Hastalar { get; }

        public IRecetelerRepository Receteler { get; }

        public IReceteDetayRepository ReceteDetay { get; }

        public ISatislarRepository Satislar { get; }

        public ISatisDetayRepository SatisDetay { get; }
    }
}
