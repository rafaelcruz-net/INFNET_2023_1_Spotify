using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool IsPublica { get; set;}
        public Usuario Usuario { get; set; }
    }
}
