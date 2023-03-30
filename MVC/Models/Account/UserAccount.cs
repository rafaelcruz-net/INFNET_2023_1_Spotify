using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;

namespace MVC.Models.Account
{
    public class UserAccount
    {
        public const string SESSION_TOKEN_KEY = "UserAccountToken";

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato do email inválido")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Password é obrigatório")]
        public string Password { get; set; }

        public string? Token { get; set; }

        public bool AutenticacaoPersistente { get; set; }

        public int Id
        {
            get
            {
                if (string.IsNullOrEmpty(Token)) 
                    return 0;

                var jwt = this.DecodeToken(Token);
                var id = jwt.Claims.First(x => x.Type == "sub").Value;
                return Convert.ToInt32(id);
            }
        }

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(Token))
                    return String.Empty;

                var jwt = this.DecodeToken(Token);
                return jwt.Claims.First(x => x.Type == "name").Value;
            }
        }

        private JwtSecurityToken DecodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            return jsonToken as JwtSecurityToken;
        }

    }
}
