namespace Entidades
{
    public class Usuario
    {
        public int Id { get; set; }   
        public string Nome { get; set;}
        public String Email { get; set; }
        public DateTime DtNascimento { get; set; }
        public string Password { get; set; }
        public List<Playlist> Playlists { get; set; }

    }
}