using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Escola
{
    public class Telefone
    {
        public string ddd { get; set; }
        public string celular { get; set; }


        /*Por que esse método se ele não é usado em nenhum lugar?*/
        public string ValidadeTelefone()
        {
            string tel = $"{ddd} {celular}";

            string padraoCelular = "[0 - 9]{ 2}[0 - 9]{ 4}[-]{ 0,1}[0 - 9]{ 4}";
            if (Regex.IsMatch(tel, padraoCelular) == false)
            {
                Console.WriteLine("NÚMERO DE TELEFONE INVÁLIDO!");
                Console.WriteLine("Ex: xxxxxx-xxxx");
            }
            return tel;
        }

        internal string Substring(int v, int v1)
        {
            throw new NotImplementedException();
        }
    }
}
