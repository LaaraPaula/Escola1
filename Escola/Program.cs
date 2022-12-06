using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var turma = new Turma();
            var professor = new Professor();
            var aluno = new Aluno();

            while (true)
            {
                Console.WriteLine("==================================================");
                MenuPrincipal();
                Console.WriteLine();
                var entrada = int.Parse(Console.ReadLine());

                switch(entrada)
                {
                    case 1:
                        {
                            Console.WriteLine("==================================================");
                            MenuSecundario();
                            Console.WriteLine();
                            var entrada2 = int.Parse(Console.ReadLine());

                            switch (entrada2)
                            {
                                case 1:
                                    professor.Cadastrar();
                                    
                                    break;
                                case 2:
                                    professor.ObterTodos();
                                    
                                    break;
                                case 3:
                                    professor.ObterPorID();
                                    
                                    break;

                                case 4:
                                    {
                                        Console.WriteLine("==================================================");
                                        MenuAtualizar();
                                        Console.WriteLine("4- Atualizar matéria aplicada ");
                                        Console.WriteLine("5- Excluir professor ");
                                        Console.WriteLine("6- Voltar ao menu anterior ");
                                        Console.WriteLine("7-Voltar ao Menu Principal ");
                                        Console.WriteLine();
                                        var atualizar = int.Parse(Console.ReadLine());

                                        switch (atualizar)
                                        {
                                            case 1:
                                                professor.AtualizarNome(professor.Professores);
                                                break;
                                            case 2:
                                                professor.AtualizarEndereco(professor.Professores);
                                                break;
                                            case 3:
                                                professor.AtualizarTelefone(professor.Professores);
                                                break;
                                            case 4:
                                                professor.AtualizarMateria(professor.Professores);
                                                break;
                                            case 5:
                                                professor.Excluir(turma.Turmas);
                                                break;
                                            case 6:
                                                MenuSecundario();
                                                break;
                                            case 7:
                                                MenuPrincipal();
                                                break;
                                        }
                                        break;
                                    }

                                case 5:
                                    professor.Excluir(turma.Turmas);
                                    
                                    break;
                                case 6:
                                    break;
                            }
                            break;

                        }
                    case 2:
                        {
                            Console.WriteLine("==================================================");
                            MenuSecundario();
                            Console.WriteLine();
                            var entrada2 = int.Parse(Console.ReadLine());

                            switch (entrada2)
                            {
                                case 1:
                                    aluno.Cadastrar(turma.Turmas);
                                    break;
                                case 2:
                                    aluno.ObterTodos();
                                    break;
                                case 3:
                                    aluno.ObterPorID();
                                    break;

                                case 4:
                                    {
                                        Console.WriteLine("==================================================");
                                        MenuAtualizar();
                                        Console.WriteLine("4-Atualizar Turma ");
                                        Console.WriteLine("5-Atualizar Periodo de estudo ");
                                        Console.WriteLine("6- Voltar ao Menu Principal ");
                                        Console.WriteLine();

                                        var atualizar = int.Parse(Console.ReadLine());

                                        switch (atualizar)
                                        {
                                            case 1:
                                                aluno.AtualizarNome(aluno.Alunos);
                                                break;

                                            case 2:
                                                aluno.AtualizarEndereco(aluno.Alunos);
                                                break;
                                            case 3:
                                                aluno.AtualizarTelefone(aluno.Alunos);
                                                break;
                                            case 4:
                                                aluno.AtualizarPeriodo(aluno.Alunos);
                                                break;



                                            case 5:
                                                aluno.AtualizarTurma(aluno.Alunos, turma.Turmas);
                                                break;
                                            case 6:
                                                MenuPrincipal();
                                                break;
                                        }
                                        break;
                                    }
                                case 5:
                                    aluno.Excluir(turma.Turmas);
                                    break;
                                case 6:
                                    MenuPrincipal();
                                    break;
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("=========================================================");
                            Console.WriteLine("1- Cadastrar Turma");
                            Console.WriteLine("2- Obter lista de Turmas");
                            Console.WriteLine("3- Pesquisar turma por código");
                            Console.WriteLine("4- Excluir uma turma");
                            Console.WriteLine("5- Adicionar Aluno na turma");
                            Console.WriteLine("6- Remover Aluno da turma");
                            Console.WriteLine("7- Listar Alunos da turma");
                            Console.WriteLine("8- Adicionar Professor na turma");
                            Console.WriteLine("9- Remover Professor da turma");
                            Console.WriteLine("10- Listar Professores da turma");
                            Console.WriteLine("11- Voltar ao Menu princpal");
                            Console.WriteLine();

                            var entrada2 = int.Parse(Console.ReadLine());

                            switch (entrada2)
                            {
                                case 1:
                                    turma.Cadastrar(professor.Professores, aluno.Alunos);
                                    break;
                                case 2:
                                    turma.ObterTodos();
                                    break;
                                case 3:
                                    turma.ObterPorID();
                                    break;
                                case 4:
                                    turma.ExcluirTurma(aluno.Alunos);
                                    break;
                                case 5:
                                    turma.AdicionarAluno(aluno.Alunos);
                                    break;
                                case 6:
                                    turma.RemoverAluno(aluno.Alunos);
                                    break;
                                case 7:
                                    turma.ObterAlunos(aluno.Alunos);
                                    turma.ObterQuantidadeAlunos(aluno.Alunos);
                                    break;
                                case 8:
                                    turma.AdicionarProfessor(professor.Professores);
                                    break;
                                case 9:
                                    turma.RemoverProfessor(professor.Professores);
                                    break;
                                case 10:
                                    turma.ObterProfessores();
                                    break;
                                case 11:
                                    MenuPrincipal();
                                    break;

                            }
                            break;
                        }

                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!!!");
                        break;
                }
            }
        }
        static void MenuPrincipal()
        {
            Console.WriteLine("1- Professor");
            Console.WriteLine("2- Aluno");
            Console.WriteLine("3- Turma");
            Console.WriteLine("4- Sair");
        }
        static void MenuSecundario()
        {
            Console.WriteLine("1- Cadastrar");
            Console.WriteLine("2- Obter lista de cadastros");
            Console.WriteLine("3- Pesquisar por código");
            Console.WriteLine("4- Atualizar cadastro");
            Console.WriteLine("5- Excluir cadastro (pesquisar por código)");
            Console.WriteLine("6- Voltar ao Menu Principal");
            
        }
        static void MenuAtualizar()
        {
            Console.WriteLine("1- Atualizar nome ");
            Console.WriteLine("2- Atualizar endereço ");
            Console.WriteLine("3- Atualizar telefone ");
        }
        
    }
}
