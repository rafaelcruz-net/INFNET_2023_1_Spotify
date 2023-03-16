using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Services.Usuario;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private UsuarioService UsuarioService { get; set; } 
        private IConfiguration Configuration { get; set; }

        public TokenController(UsuarioService usuarioService, IConfiguration configuration)
        {
            this.UsuarioService = usuarioService;
            Configuration = configuration;
        }

        [HttpPost("")]
        public IActionResult Token([FromBody] TokenRequest request) 
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var user = this.UsuarioService.AutenticarUsuario(request.email, request.password);

            if (user == null)
                return Unauthorized();

            return Ok(new
            {
                AccessToken = this.GenerateToken(user)
            });
        
        }

        private string GenerateToken(Entidades.Usuario user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("sub", user.Id.ToString()),
                new Claim("email", user.Email),
                new Claim("name", user.Nome)
            };

            var key = Encoding.Default.GetBytes(this.Configuration["TokenSecret"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            
            var securityToken = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = "spotify-token",
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(securityToken);

            return tokenHandler.WriteToken(token);
        }

    }

    public record TokenRequest(
        [Required(ErrorMessage = "Email é obrigatório")] string email, 
        [Required(ErrorMessage = "Password é obrigatório") ] string password);
}
