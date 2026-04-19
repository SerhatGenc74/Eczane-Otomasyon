using EczaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Bussines.Services.Interfaces
{
    public interface IIlaclarService
    {
        List<Ilaclar> TumIlaclariGetir();
        bool IlacEkle(Ilaclar ilac);
        bool IlacGuncelle(Ilaclar ilac);
        bool IlacSil(int ilacId);

        List<Ilaclar> KritikStoktakiIlaclariGetir();
        List<Ilaclar> MiadiYaklasanIlaclariGetir(int kacGunKaldi = 30);
    }
}
