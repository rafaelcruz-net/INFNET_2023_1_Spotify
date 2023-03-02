using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exception
{
    public class BusinessException : System.Exception
    {
        public string title { get; set; }
        public string message { get; set; }

        public BusinessException(string message, string title = "Aconteceu uma exceção ao processar sua requisição") : base(message)
        {
            this.title = title;
            this.message = message;
        }

    }
}
