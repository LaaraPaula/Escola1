using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola
{
    public class Endereco
    {
        public int idEndereco { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string cep { get;set; }
        public string estadoUF { get; set; }

        public static implicit operator string(Endereco v)
        {
            throw new NotImplementedException();
        }
    }
}
