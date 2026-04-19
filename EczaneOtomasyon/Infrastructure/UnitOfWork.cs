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
                          IKullanicilarRepository kullanicilar)
        {
            Ilaclar = ilaclar ?? throw new ArgumentNullException(nameof(ilaclar));
            Kullanicilar = kullanicilar ?? throw new ArgumentNullException(nameof(kullanicilar));

        }

        public IIlaclarRepository Ilaclar { get; }
        public IKullanicilarRepository Kullanicilar { get; }
    }
}
