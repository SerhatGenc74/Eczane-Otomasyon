using EczaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Bussines.Services.Interfaces
{
    public interface IKullanicilarService
    {
        List<Kullanicilar> GetAllUsers();
        bool KullaniciEkle(Kullanicilar kullanici);
        bool KullaniciGuncelle(Kullanicilar kullanici);
        bool DeleteUser(int id);
        bool ChangePassword(int kullaniciId, string yeniSifre);
        Kullanicilar Login(string kullaniciAdi, string sifre);
       

    }
}
