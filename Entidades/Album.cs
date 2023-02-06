using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Album
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Banda Banda { get; set; }
        public List<Musica> Musicas { get; set; }
    }
}
