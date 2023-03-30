using Microsoft.AspNetCore.Identity;

namespace MVC.Repository
{
    public interface IAccountManager
    {
        Task<SignInResult> Login(string email, string password, bool cookiePersistente = false);
        Task Logout();
    }
}
