using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using MVC.Models.Account;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MVC.Repository
{
    public class AccountManager : IAccountManager
    {
        private SignInManager<UserAccount> SignInManager { get; set; }
        private RoleManager<UserRole> RoleManager { get; set; }
        private HttpContext HttpContext { get; set; }

        public AccountManager(SignInManager<UserAccount> signInManager, IHttpContextAccessor httpContextAccessor, RoleManager<UserRole> roleManager)
        {
            SignInManager = signInManager;
            HttpContext = httpContextAccessor.HttpContext;
            RoleManager = roleManager;
        }

        public async Task<SignInResult> Login(string email, string password, bool cookiePersistente = false)
        {
            var token = GetToken(email, password);

            if (string.IsNullOrEmpty(token) == true) 
            {
                return SignInResult.Failed;
            }

            var user = new UserAccount
            {
                Email = email,
                Password = password,
                Token = token
            };

            var claimsPrincipal = await SignInManager.CreateUserPrincipalAsync(user);
            (claimsPrincipal.Identity as ClaimsIdentity).AddClaim(new Claim(ClaimTypes.Role, user.Perfil));

            await SignInManager.Context.SignInAsync(IdentityConstants.ApplicationScheme, claimsPrincipal, new AuthenticationProperties
            {
                IsPersistent = cookiePersistente
            });



            //Grava o token na Sessão
            HttpContext.Session.SetString(UserAccount.SESSION_TOKEN_KEY, token);

            return SignInResult.Success;
            
        }

        public async Task Logout()
        {
            await SignInManager.SignOutAsync();
        }

        private string GetToken(string email, string password)
        {
            var user = new
            {
                email = email,
                password = password
            };

            var body = new StringContent(JsonSerializer.Serialize(user), new MediaTypeHeaderValue("application/json"));

            HttpClient httpClient = new HttpClient();
            var response = httpClient.PostAsync("https://localhost:7031/api/token", body).Result;

            if (response.IsSuccessStatusCode == false)
                return String.Empty;

            var json = response.Content.ReadAsStringAsync().Result;
            var token = JsonSerializer.Deserialize<Token>(json);

            return token.AccessToken;
        }
    }
}
public class Token
{
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }
}
