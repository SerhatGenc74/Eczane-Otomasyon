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
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<Kullanicilar> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public void KullaniciEkle(Kullanicilar kullanici)
        {
            throw new NotImplementedException();
        }

        public Kullanicilar Login(string kullaniciAdi, string sifre)
        {
            var kullanici = _db.Kullanicilar.GetAll().Where(x => x.KullaniciAdi == kullaniciAdi && x.Sifre == sifre).FirstOrDefault();
            return kullanici;
           
        }
    }
}
