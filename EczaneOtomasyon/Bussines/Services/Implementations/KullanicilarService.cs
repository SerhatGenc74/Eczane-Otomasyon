using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Domain.Interfaces;
using EczaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Bussines.Services.Implementations
{
    public class KullanicilarService : IKullanicilarService
    {
        IUnitOfWork _db;
        public KullanicilarService(IUnitOfWork db)
        {
            _db = db;
        }

        public bool ChangePassword(int kullaniciId, string yeniSifre)
        {
            if (kullaniciId <= 0 || string.IsNullOrWhiteSpace(yeniSifre))
            {
                return false;
            }

            return _db.Kullanicilar.Update(kullaniciId, new { Sifre = yeniSifre });
        }

        public bool DeleteUser(int id)
        {
            return _db.Kullanicilar.Delete(id);
        }

        public List<Kullanicilar> GetAllUsers()
        {
            return _db.Kullanicilar.GetAll();
        }

        public bool KullaniciEkle(Kullanicilar kullanici)
        {
            if (kullanici == null)
            {
                return false;
            }

            return _db.Kullanicilar.Add(kullanici);
        }

        public bool KullaniciGuncelle(Kullanicilar kullanici)
        {
            if (kullanici == null)
            {
                return false;
            }

            return _db.Kullanicilar.Update(kullanici.KullaniciID, kullanici);
        }

        public Kullanicilar Login(string kullaniciAdi, string sifre)
        {
            var kullanici = _db.Kullanicilar.GetAll().Where(x => x.KullaniciAdi == kullaniciAdi && x.Sifre == sifre).FirstOrDefault();
            return kullanici;
           
        }
    }
}
