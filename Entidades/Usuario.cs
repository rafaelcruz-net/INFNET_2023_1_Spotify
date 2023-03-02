using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace Entidades
{
    public class Usuario
    {
        public Usuario()
        {
            this.Playlists = new List<Playlist>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é Obrigatório")]
        public string Nome { get; set;}
        
        [Required(ErrorMessage = "Email é Obrigatório")]
        [EmailAddress(ErrorMessage = "Email não está em um formato correto")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Data de nascimento é Obrigatório")]
        public DateTime DtNascimento { get; set; }
        
        [Required(ErrorMessage = "Senha é Obrigatório")]
        public string Password { get; set; }
        public List<Playlist> Playlists { get; set; }

        public void CriarPlaylist(string nome, bool isPublic)
        {
            var play = new Playlist()
            {
                Nome = nome,
                IsPublica = isPublic,
                Usuario = this
            };

            this.Playlists.Add(play);

        }

        public void CriptografarPassword()
        {
            this.Password = Convert.ToBase64String(Encoding.Default.GetBytes(this.Password)); 
        }

        public void ExcluirPlaylist(Playlist playlist)
        {
            this.Playlists.Remove(playlist);
        }

    }
}