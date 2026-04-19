using System;

namespace EczaneOtomasyon.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IIlaclarRepository Ilaclar { get; }
        IKullanicilarRepository Kullanicilar { get; }
    }
}
