using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Banda
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string FotoBanda { get; set; }
        public string Descricao { get; set; }
        public List<Album> Albuns { get; set; }
    }
}
