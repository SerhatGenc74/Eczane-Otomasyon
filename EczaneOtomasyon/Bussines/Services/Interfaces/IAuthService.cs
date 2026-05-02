using EczaneOtomasyon.Models;

namespace EczaneOtomasyon.Bussines.Services.Interfaces
{
    public interface IAuthService
    {
        void SetCurrentUser(Kullanicilar user);
        Kullanicilar GetCurrentUser();
    }
}
