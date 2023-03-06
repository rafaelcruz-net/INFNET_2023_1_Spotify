using Entidades;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Exception;
using Microsoft.EntityFrameworkCore;

namespace Services.Usuario
{
    public class UsuarioService
    {
        private SpotifyContext context;

        public UsuarioService(SpotifyContext _context) 
        {
            this.context = _context;
        }

        public IEnumerable<Entidades.Usuario> ObterUsuario()
        {
            return context.Usuarios.Include(x => x.Playlists);
        }


        public Entidades.Usuario ObterUsuarioPorId(int id)
        {
            return context.Usuarios.Include(x => x.Playlists).FirstOrDefault(x => x.Id == id);
        }

        public Entidades.Usuario SalvarUsuario(Entidades.Usuario usuario)
        {
            var user = this.context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);

            if (user != null) 
                throw new BusinessException("Email já cadastrado na base de dados, por favor utilize outro");
            
            //Cria a playlist do usuário ao criar
            usuario.CriarPlaylist("Musicas Favoritas", false);

            // Criar o hash do password, baseado na propriedade
            usuario.CriptografarPassword();

            this.context.Usuarios.Add(usuario);
            this.context.SaveChanges();

            return usuario;
        }

        public Entidades.Usuario AtualizarUsuario(Entidades.Usuario usuarioNew)
        {
            var user = this.context.Usuarios.FirstOrDefault(x => x.Id == usuarioNew.Id);

            user.Nome = usuarioNew.Nome;
            user.Email = usuarioNew.Email;
            user.DtNascimento = usuarioNew.DtNascimento;
            user.Password = usuarioNew.Password;

            // Criar o hash do password, baseado na propriedade
            user.CriptografarPassword();

            this.context.Usuarios.Update(user);
            this.context.SaveChanges();

            return user;

        }

        public void ExcluirUsuario(Entidades.Usuario usuario)
        {
            this.context.Usuarios.Remove(usuario);
            this.context.SaveChanges();
        }

    }
}
