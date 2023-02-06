using System.Diagnostics;

namespace Entidades
{
    public class Usuario
    {
        public Usuario()
        {
            this.Playlists = new List<Playlist>();
        }

        public int Id { get; set; }   
        public string Nome { get; set;}
        public String Email { get; set; }
        public DateTime DtNascimento { get; set; }
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

        public void ExcluirPlaylist(Playlist playlist)
        {
            this.Playlists.Remove(playlist);
        }

    }
}