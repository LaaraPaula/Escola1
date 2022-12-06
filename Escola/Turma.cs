using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Escola
{
    public class Turma
    {
        public List<Turma> Turmas = new List<Turma>();


        public int IdTurma { get; set; }
        public string AnoEscolar { get; set; }
        public List<Professor> Professores { get; set; } = new List<Professor>();
        public string msg = "Código de turma não encontrado...";


        public void Cadastrar(List<Professor> professores, List<Aluno> alunos)

        {
            var _idTurma = 0;
            
            while (true)
            {
                Console.WriteLine("Digite o Código da turma: ");
                var _idTurmaStr = Console.ReadLine();
                if (!Regex.IsMatch(_idTurmaStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _idTurma = int.Parse(_idTurmaStr);
                    var existeTurma = Turmas.Any(x => x.IdTurma == _idTurma);
                    if (!existeTurma)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Código da Turma já EXISTE!!");
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine();
            var _anoEscolar = "";

            while (true)
            {
                Console.WriteLine("Digite o Ano escolar ");
                _anoEscolar = Console.ReadLine();
                if (!Regex.IsMatch(_anoEscolar, @"^[1-9][a-zA-Z\x20]+$"))
                {
                    Console.WriteLine("CADASTRO DE TURMA INCORRETO!");
                    Console.WriteLine("Ex: 1 Ano ou Ex2: 1Ano");
                }
                else
                {
                    break;
                }
            }
            var novaTurma = new Turma
            {
                IdTurma = _idTurma,
                AnoEscolar = _anoEscolar.ToUpper()
            };
            Turmas.Add(novaTurma);
            Console.WriteLine("Turma Cadastrada com sucesso!!");
            Console.WriteLine("==================================================");
        }
        public void ObterTodos()
        {
            var listaOrdenada =Turmas.OrderBy(c => c.AnoEscolar).ToList();
            foreach (var item in listaOrdenada)
            {
                Console.WriteLine($"ID:{item.IdTurma}\tAno Escolar:{item.AnoEscolar}");
            }
            if (listaOrdenada.Count == 0)
            {
                Console.WriteLine("Não existe nenhuma truma cadastrada!");
            }
            Console.WriteLine();
        }
        public void ObterPorID()
        {
            var _id = 0;
            while (true)
            {
                Console.WriteLine("Digite o código da Turma:");
                Console.WriteLine();
                var _idTurmaStr =Console.ReadLine();
                if (!Regex.IsMatch(_idTurmaStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _id = int.Parse(_idTurmaStr);

                    var turma = Turmas.FirstOrDefault(x => x.IdTurma == _id);
                    if (turma != null)
                    {
                        Console.WriteLine($"ID: {turma.IdTurma}\tAno Escolar: {turma.AnoEscolar}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine(msg);
                        break;
                    }
                }
            }
            Console.WriteLine();
        }
        public void ExcluirTurma(List<Aluno> alunos)
        {
            var _id = 0;
            while (true)
            {
                Console.WriteLine("Digite o código da Turma:");
                Console.WriteLine();
                var _idTurmaStr = Console.ReadLine();

                if (!Regex.IsMatch(_idTurmaStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _id = int.Parse(_idTurmaStr);

                    var turmaEncontrada = Turmas.FirstOrDefault(x => x.IdTurma == _id);
                    if (turmaEncontrada != null)
                    {
                        var quantidadeAlunos = alunos.Where(x => x.IdDaTurma == turmaEncontrada.IdTurma).Count();

                        if (quantidadeAlunos == 0)
                        {
                            Turmas.Remove(turmaEncontrada);
                            Console.WriteLine($"Turma {turmaEncontrada.AnoEscolar} removida com sucesso!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ainda existem alunos matriculados nesta turma, vc precisa removê-los antes");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine(msg);
                        break;
                    }
                }
                
            }
            Console.WriteLine();
        }
        public void AdicionarAluno(List<Aluno> alunos)
        {
            var _idAluno = 0;
            while (true)
            {
                Console.WriteLine("Digite o código do Aluno:");
                Console.WriteLine();
                var _idAlunoStr = Console.ReadLine();

                if (!Regex.IsMatch(_idAlunoStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _idAluno = int.Parse(_idAlunoStr);

                    var alunoEncontrado = alunos.FirstOrDefault(x => x.IdPessoa == _idAluno);

                    if (alunoEncontrado != null)
                    {
                        var _id = 0;
                        while (true)
                        {
                            Console.WriteLine("Digite o código da Turma:");
                            Console.WriteLine();
                            var _idTurmaStr = Console.ReadLine();

                            if (!Regex.IsMatch(_idTurmaStr, @"^[0-9]+$"))
                            {
                                Console.WriteLine("Código aceita apenas números");
                            }
                            else
                            {
                                _id = int.Parse(_idTurmaStr);

                                var turmaEncontrada = Turmas.FirstOrDefault(x => x.IdTurma == _id);
                                if (turmaEncontrada != null)
                                {
                                    alunoEncontrado.IdDaTurma = turmaEncontrada.IdTurma;
                                    Console.WriteLine($"Aluno(a) {alunoEncontrado.Nome} adicionado a turma com sucesso!");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Código da turma não encontrado...");
                                    break;
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Código do aluno não encontrado...");
                        break;
                    }
                }
            }
            Console.WriteLine();
        }
        public void RemoverAluno(List<Aluno> alunos)
        {
            var _id = 0;
            while (true)
            {
                Console.WriteLine("Digite o código da Turma:");
                Console.WriteLine();
                var _idTurmaStr = Console.ReadLine();

                if (!Regex.IsMatch(_idTurmaStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _id = int.Parse(_idTurmaStr);
                    var turmaEncontrada = Turmas.FirstOrDefault(x => x.IdTurma == _id);
                    if (turmaEncontrada != null)
                    {
                        var _idAluno = 0;
                        while (true)
                        {
                            Console.WriteLine("Digite o código do Aluno:");
                            Console.WriteLine();
                            var _idAlunoStr = Console.ReadLine();

                            if (!Regex.IsMatch(_idAlunoStr, @"^[0-9]+$"))
                            {
                                Console.WriteLine("Código aceita apenas números");
                            }
                            else
                            {
                                _idAluno = int.Parse(_idAlunoStr);
                                var alunoEncontrado = alunos.FirstOrDefault(x => x.IdPessoa == _idAluno);
                                if (alunoEncontrado != null)
                                {
                                    alunoEncontrado.IdDaTurma = 0;
                                    Console.WriteLine($"Aluno(a) {alunoEncontrado.Nome} removido(a) da turma com sucesso!");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Código do aluno não encontrado...");
                                    break;
                                }
                            }
                        }
                       
                    }
                    else
                    {
                        Console.WriteLine("Código da turma não encontrado...");
                        break;
                    }
                }
            }
            Console.WriteLine();
        }
        public void ObterAlunos(List<Aluno> alunos)
        {
            var _id = 0;
            while (true)
            {
                Console.WriteLine("Digite o código da Turma:");
                Console.WriteLine();
                var _idTurmaStr = Console.ReadLine();

                if (!Regex.IsMatch(_idTurmaStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _id = int.Parse(_idTurmaStr);

                    var turmaEncontrada = Turmas.FirstOrDefault(x => x.IdTurma == _id);
                    if (turmaEncontrada != null)
                    {
                        var listaOrdenada = alunos.OrderBy(c => c.Nome).ToList();
                        var alunosTurma = listaOrdenada.Where(x => x.IdDaTurma == _id);
                        foreach (var item in alunosTurma)
                        {
                            Console.WriteLine($"Nome: {item.Nome} ID: {item.IdPessoa}");

                            Console.WriteLine();

                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine(msg);
                        break;
                    }
                }

            }
            Console.WriteLine();
        }
        public void ObterQuantidadeAlunos(List<Aluno> alunos)
        {
            var _id = 0;
            while (true)
            {
                Console.WriteLine("Digite o código da Turma para ver a quantidade de alunos nela:");
                Console.WriteLine();
                var _idTurmaStr = Console.ReadLine();

                if (!Regex.IsMatch(_idTurmaStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _id = int.Parse(_idTurmaStr);

                    var quantidade = alunos.Where(x => x.IdDaTurma == _id).Count();
                    Console.WriteLine($"A turma tem {quantidade} alunos.");
                    break;
                }
            }
            Console.WriteLine();
        }
        public void AdicionarProfessor(List<Professor> professores) 
        {
            var _idProf = 0;
            while (true)
            {
                Console.WriteLine("Digite o código do Professor:");
                Console.WriteLine();
                var _idProfStr = Console.ReadLine();

                if (!Regex.IsMatch(_idProfStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _idProf = int.Parse(_idProfStr);

                    var profEncontrado = professores.FirstOrDefault(x => x.IdPessoa == _idProf);

                    if (profEncontrado != null)
                    {
                        var _id = 0;
                        while (true)
                        {
                            Console.WriteLine("Digite o código da Turma:");
                            Console.WriteLine();
                            var _idTurmaStr = Console.ReadLine();

                            if (!Regex.IsMatch(_idTurmaStr, @"^[0-9]+$"))
                            {
                                Console.WriteLine("Código aceita apenas números");
                            }
                            else
                            {
                                _id = int.Parse(_idTurmaStr);

                                var turmaEncontrada = Turmas.FirstOrDefault(x => x.IdTurma == _id);
                                if (turmaEncontrada != null)
                                {
                                    turmaEncontrada.Professores.Add(profEncontrado);
                                    Console.WriteLine($"Professor(a) {profEncontrado.Nome} de {profEncontrado.materia} adicionado a turma com sucesso!");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Código da turma não encontrado...");
                                    break;
                                }
                            }
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Código de professor não encontrado");
                        break;
                    }
                }
            }
            Console.WriteLine();
        }
        public void RemoverProfessor(List<Professor> professores)
        {
            var _id = 0;
            while (true)
            {
                Console.WriteLine("Digite o código da Turma:");
                Console.WriteLine();
                var _idTurmaStr = Console.ReadLine();

                if (!Regex.IsMatch(_idTurmaStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _id = int.Parse(_idTurmaStr);

                    var turmaEncontrada = Turmas.FirstOrDefault(x => x.IdTurma == _id);
                    if (turmaEncontrada != null)
                    {
                        var _idProf = 0;
                        while (true)
                        {
                            Console.WriteLine("Digite o código da Turma:");
                            Console.WriteLine();
                            var _idProfStr = Console.ReadLine();

                            if (!Regex.IsMatch(_idProfStr, @"^[0-9]+$"))
                            {
                                Console.WriteLine("Código aceita apenas números");
                            }
                            else
                            {
                                _idProf = int.Parse(_idTurmaStr);

                                var professorEncontrado = professores.FirstOrDefault(x => x.IdPessoa == _idProf);
                                if (professorEncontrado != null)
                                {
                                    turmaEncontrada.Professores.Remove(professorEncontrado);
                                    Console.WriteLine($"Professor {professorEncontrado.Nome} de {professorEncontrado.materia} removido com sucesso!");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Código do professor não encontrado...");
                                    break;
                                }
                            }
                        }
                       
                    }
                    else
                    {
                        Console.WriteLine("Código da turma não encontrado...");
                        break;
                    }
                }
            }
            Console.WriteLine();
        }
        public void ObterProfessores()
        {
            var _id = 0;
            while (true)
            {
                Console.WriteLine("Digite o código da Turma:");
                Console.WriteLine();
                var _idTurmaStr = Console.ReadLine();

                if (!Regex.IsMatch(_idTurmaStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _id = int.Parse(_idTurmaStr);

                    var turmaEncontrada = Turmas.FirstOrDefault(x => x.IdTurma == _id);
                    if (turmaEncontrada != null)
                    {
                        var listaOrdenada = turmaEncontrada.Professores.OrderBy(c => c.Nome).ToList();
                        foreach (var item in listaOrdenada)
                        {
                            Console.WriteLine($"Nome: {item.Nome} ID: {item.IdPessoa} Matéria:{item.materia}");

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine(msg);
                        break;
                    }
                }
            }
        }
    }
}
