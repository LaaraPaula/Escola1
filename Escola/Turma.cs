using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Escola
{
    public class Turma
    {
        public List<Turma> Turmas = new List<Turma>();


        public int IdTurma { get; set; }
        public string AnoEscolar { get; set; }
        public List<Professor> Professores { get; set; } = new List<Professor>();



        public void Cadastrar(List<Professor> professores, List<Aluno> alunos)

        {
            Console.WriteLine("Digite o Código da turma: ");
            var _idTurma = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Ano Escolar desta turma: ");
            var _anoEscolar = Console.ReadLine();

            var novaTurma = new Turma
            {
                IdTurma = _idTurma,
                AnoEscolar = _anoEscolar
            };
            Turmas.Add(novaTurma);
        }
        public object ObterTodos()
        {
            return Turmas;
        }
        public object ObterPorID()
        {
            Console.WriteLine("Digite o código da Turma :");
            var _id = int.Parse(Console.ReadLine());

            var Pesquisarturmas = Turmas.FirstOrDefault(x => x.IdTurma == _id);

            return Pesquisarturmas;
        }
        public void ExcluirTurma(List<Aluno> alunos) /*Onde está sendo usado esse ExcluirTurma?*/
        {
            Console.WriteLine("Digite o código da turmaque deseja excluir: ");
            var _cdTurma = int.Parse(Console.ReadLine());
            var turmaEncontrada = Turmas.FirstOrDefault(x => x.IdTurma == _cdTurma);
            if (turmaEncontrada != null)
            {
                var quantidadeAlunos = alunos.Where(x => x.IdDaTurma == turmaEncontrada.IdTurma).Count();

                if (quantidadeAlunos == 0)
                {
                    Turmas.Remove(turmaEncontrada);
                }
                else
                {
                    Console.WriteLine("Ainda existem alunos matriculados nesta turma");
                }
            }
            else /*Resposta certa se eu não encontrar uma turma?*/
            {
                Console.WriteLine("Ainda existem alunos registrados na turma");
            }

        }


        public void AdicionarAluno(List<Aluno> alunos)
        {
            Console.WriteLine("Digite a matrícula do aluno para adicioná-lo a turma: ");
            var matricula = int.Parse(Console.ReadLine());

            var alunoEncontrado = alunos.FirstOrDefault(x => x.IdPessoa == matricula);

            if (alunoEncontrado != null)
            {
                Console.WriteLine("Digite o código da turma a qual predente adicioná-lo: ");
                var _cdTurma = int.Parse(Console.ReadLine());

                var turmaEncontrada = Turmas.FirstOrDefault(x => x.IdTurma == _cdTurma);
                if (turmaEncontrada != null)
                {
                    alunoEncontrado.IdDaTurma = turmaEncontrada.IdTurma;

                }
                else
                {
                    Console.WriteLine("Código da turma não encontrado...");
                }
            }
            else
            {
                Console.WriteLine("Código do aluno não encontrado...");
            }

        }
        public void RemoverAluno(List<Aluno> alunos)
        {
            Console.WriteLine("Digite o código da turma: ");
            var _cdTurma = int.Parse(Console.ReadLine());

            var turmaEncontrada = Turmas.FirstOrDefault(x => x.IdTurma == _cdTurma);
            if (turmaEncontrada != null)
            {
                Console.WriteLine("Digite a matrícula do aluno removê-lo da turma: ");
                var matricula = int.Parse(Console.ReadLine());
                var alunoEncontrado = alunos.FirstOrDefault(x => x.IdPessoa == matricula);
                if (alunoEncontrado != null)
                {
                    alunoEncontrado.IdDaTurma = 0;
                }
                else
                {
                    Console.WriteLine("Código do aluno não encontrado...");
                }
            }
            else
            {
                Console.WriteLine("Código da turma não encontrado...");
            }
        }
        public object ObterAlunos(List<Aluno> alunos)
        {
            var _idTurma = 1;
            return alunos.Where(x => x.IdDaTurma == _idTurma);
        }
        public int ObterQuantidadeAlunos(List<Aluno> alunos) /*Onde está sendo usado?*/
        {
            var idTurma = 1;

            var quantidade = alunos.Where(x => x.IdDaTurma == idTurma).Count();
            return quantidade;
        }


        public void AdicionarProfessor(List<Professor> professores)
        {
            Console.WriteLine("Digite o id do professor para adicioná-lo");
            var prof = int.Parse(Console.ReadLine());


            var profEncontrado = professores.FirstOrDefault(x => x.IdPessoa == prof);

            if (profEncontrado != null)
            {
                Console.WriteLine("Digite o código da turma a qual predente adicioná-lo: ");
                var _cdTurma = int.Parse(Console.ReadLine());

                var turmaEncontrada = Turmas.FirstOrDefault(x => x.IdTurma == _cdTurma);
                if (turmaEncontrada != null)
                {
                    turmaEncontrada.Professores.Add(profEncontrado);
                }
                else
                {
                    Console.WriteLine("Código da turma não encontrado...");
                }
            }
            else
            {
                Console.WriteLine("Código de professor não encontrado");
            }
        }
        public void RemoverProfessor(List<Professor> professores)
        {
            Console.WriteLine("Digite o código da turma: ");
            var _cdTurma = int.Parse(Console.ReadLine());

            var turmaEncontrada = Turmas.FirstOrDefault(x => x.IdTurma == _cdTurma);
            if (turmaEncontrada != null)
            {
                Console.WriteLine("Digite o código do professor removê-lo da turma: ");
                var matricula = int.Parse(Console.ReadLine());

                var professorEncontrado = professores.FirstOrDefault(x => x.IdPessoa == matricula);
                if (professorEncontrado != null)
                {
                    turmaEncontrada.Professores.Remove(professorEncontrado);
                }
                else
                {
                    Console.WriteLine("Código do professor não encontrado...");
                }
            }
            else
            {
                Console.WriteLine("Código da turma não encontrado...");
            }
        }
        public object ObterProfessores()
        {
            Console.WriteLine("Digite o código da turma para exibir os professores: ");
            var _cdTurma = int.Parse(Console.ReadLine());

            var turmaEncontrada = Turmas.FirstOrDefault(x => x.IdTurma == _cdTurma);
            if (turmaEncontrada != null)
            {
                return turmaEncontrada.Professores;
            }
            string msg = "Código de turma não encontrado";
            return msg;
        }
    }
}
