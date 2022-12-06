using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola
{

    public static class Validacao
    {
        public static void ValidarTelefone(Telefone _telefone)
        {
            if (String.IsNullOrEmpty(_telefone.ddd) && String.IsNullOrEmpty(_telefone.celular))
            {
                throw new ArgumentException("O telefone não pode ser nulo ou vazio. ", nameof(_telefone));
            }

        }
        public static void ValidarTurma(Turma _idTurma)
        {
            if (String.IsNullOrEmpty(_idTurma.ToString()))
            {
                throw new ArgumentException("O Código da Turma não pode ser nulo ou vazio. ", nameof(_idTurma));
            }
        }

        public static void ValidarAluno(Aluno _idAluno)
        {
            if (String.IsNullOrEmpty(_idAluno.ToString()))
            {
               
            }
        }
        public static void ValidarProfessor(Aluno _idProf)
        {
            if (String.IsNullOrEmpty(_idProf.ToString()))
            {
                throw new ArgumentException("O Código do Professor não pode ser nulo ou vazio. ", nameof(_idProf));
            }
        }        
    }
}
