using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Models;

namespace EczaneOtomasyon.Bussines.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private Kullanicilar _current;

        public void SetCurrentUser(Kullanicilar user)
        {
            _current = user;
        }

        public Kullanicilar GetCurrentUser()
        {
            return _current;
        }
    }
}
