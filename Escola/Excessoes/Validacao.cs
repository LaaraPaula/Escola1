using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola
{

    public class Validacao
    {
        public Validacao(Telefone _telefone)
        {
            if (String.IsNullOrEmpty(_telefone.ToString()))
            {
                throw new ArgumentException("O telefone não pode ser nulo ou vazio. ", nameof(_telefone));
            }
        }
        public Validacao(Turma _idTurma)
        {
            if (String.IsNullOrEmpty(_idTurma.ToString()))
            {
                throw new ArgumentException("O Código da Turma não pode ser nulo ou vazio. ", nameof(_idTurma));
            }
        }
        public Validacao(Aluno _idAluno)
        {
            if (String.IsNullOrEmpty(_idAluno.ToString()))
            {
                throw new ArgumentException("O Código do Aluno não pode ser nulo ou vazio. ", nameof(_idAluno));
            }
        }
        public Validacao(Professor _idProf)
        {
            if (String.IsNullOrEmpty(_idProf.ToString()))
            {
                throw new ArgumentException("O Código do Professor não pode ser nulo ou vazio. ", nameof(_idProf));
            }
        }        
    }
}
