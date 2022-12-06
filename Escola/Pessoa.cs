
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola
{
    public abstract class Pessoa
    {
        public int IdPessoa { get; protected set; }
        public string Nome { get; set; }
        public Telefone Telefone { get; set; }
        public Endereco Endereco { get; set; }

        public Pessoa()
        {

        }

        public Pessoa(int idPessoa, string nome, Telefone telefone, Endereco endereco)
        {
            IdPessoa = idPessoa;
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;

        }
        public abstract void Cadastrar();
        public abstract void Cadastrar(List<Turma>turmas);
        public abstract void ObterTodos();
        public abstract void ObterPorID();
        public abstract void Excluir(List<Turma> turmas);
    }
}
