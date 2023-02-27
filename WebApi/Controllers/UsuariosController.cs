using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private SpotifyContext context;

        public UsuariosController(SpotifyContext _context)
        {
            this.context = _context;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.context.Usuarios);
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = this.context.Usuarios.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
            
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var user = this.context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);

            if (user != null)
            {
                return UnprocessableEntity(new
                {
                    Errors = "Email já cadastrado na base de dados, por favor utilize outro"
                });
            }

            this.context.Usuarios.Add(usuario);
            this.context.SaveChanges();

            return Created($"/usuarios/{usuario.Id}", usuario);
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuarioNew)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var user = this.context.Usuarios.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.Nome = usuarioNew.Nome;
            user.Email = usuarioNew.Email;
            user.DtNascimento = usuarioNew.DtNascimento;
            user.Password = usuarioNew.Password;

            this.context.Usuarios.Update(user);
            this.context.SaveChanges();

            return Ok(user);

        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = this.context.Usuarios.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            this.context.Usuarios.Remove(user);
            this.context.SaveChanges();

            return NoContent();

        }
    }
}
