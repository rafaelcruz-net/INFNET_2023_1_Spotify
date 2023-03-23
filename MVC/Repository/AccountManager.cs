using Microsoft.AspNetCore.Identity;
using MVC.Models.Account;

namespace MVC.Repository
{
    public class AccountManager : IAccountManager
    {
        private SignInManager<UserAccount> SignInManager { get; set; }

        public AccountManager(SignInManager<UserAccount> signInManager)
        {
            SignInManager = signInManager;
        }

        public async Task<SignInResult> Login(string email, string password)
        {
            await SignInManager.SignInAsync(new UserAccount
            {

            }, true);

            return SignInResult.Success;
        }

        public async Task Logout()
        {
            await SignInManager.SignOutAsync();
        }


    }


}
