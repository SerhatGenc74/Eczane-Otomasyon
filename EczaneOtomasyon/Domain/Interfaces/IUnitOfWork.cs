using System;

namespace EczaneOtomasyon.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IIlaclarRepository Ilaclar { get; }
        IKullanicilarRepository Kullanicilar { get; }
        IKategoriRepository Kategori { get; }
        IReceteTurRepository ReceteTur { get; }
        IDoktorlarRepository Doktorlar { get; }
        IHastalarRepository Hastalar { get; }
        IRecetelerRepository Receteler { get; }
        IReceteDetayRepository ReceteDetay { get; }
        ISatislarRepository Satislar { get; }
        ISatisDetayRepository SatisDetay { get; }
    }
}
