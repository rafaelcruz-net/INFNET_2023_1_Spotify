using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    public class Playlist
    {
        public Playlist()
        {
            this.Musicas = new List<Musica>(); 
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool IsPublica { get; set;}
        
        [JsonIgnore]
        public Usuario Usuario { get; set; }
        public List<Musica> Musicas { get; set;}

        public void AdicionarMusica(Musica musica)
        {
            if (this.Musicas.Any(x => x.Id == musica.Id))
            {
                throw new Exception("Essa música já está inserida na playlist");
            }

            this.Musicas.Add(musica);
        }

        public void ExcluirMusica(Musica musica)
        {
            this.Musicas.Remove(musica);
        }
    }
}
