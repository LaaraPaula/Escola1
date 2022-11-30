using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola
{
    internal class Program
    {

        /*
         * Melhorar condição do menu - Utilizar switch - case
         * Segue link de apoio: https://www.w3schools.com/cs/cs_switch.php
         * 
         * Formatar exibição do terminal melhor. Informaçõs ficam confusas, terminal fica poluído.
         * Necessário usar o Try Catch
         * Verifique erros de português, de escrita...
         */

        static void Main(string[] args)
        {
            var turma = new Turma();
            var professor = new Professor();
            var aluno = new Aluno();

            while (true)
            {

                MenuPrincipal();
                var entrada = Console.ReadLine();


                if (entrada == "1")
                {
                    MenuSecundario();

                    var entrada2 = Console.ReadLine();
                    if (entrada2 == "1")
                    {
                        professor.Cadastrar();
                    }
                    else if (entrada2 == "2")
                    {
                        professor.ObterTodos(); /*Não exibe no terminal*/
                    }
                    else if (entrada2 == "3")
                    {
                        professor.ObterPorID(); /*Não exibe no terminal*/
                    }
                    else if (entrada2 == "4")
                    {
                        MenuAtualizar();
                        Console.WriteLine("4- Atualizar matéria aplicada ");
                        Console.WriteLine("5- Voltar ao menu anterior ");
                        Console.WriteLine("6-Voltar ao Menu Principal ");
                        var atualizar = Console.ReadLine();

                        if(atualizar=="1")
                        {
                            professor.AtualizarNome(professor.Professores);
                        }
                        else if (atualizar == "2")
                        {
                            professor.AtualizarEndereco(professor.Professores);
                        }
                        else if (atualizar == "3")
                        {
                            professor.AtualizarTelefone(professor.Professores);
                        }
                        else if (atualizar == "4")
                        {
                            professor.AtualizarMateria(professor.Professores);
                        }
                        else if (atualizar == "5")
                        {
                            MenuSecundario();
                        }
                        else if (atualizar == "6")
                        {
                            MenuPrincipal();
                        }
                    }
                    else if (entrada2 == "5")
                    {
                        professor.Excluir(turma.Turmas);
                    }
                    else if (entrada2 == "6")
                    {
                        MenuPrincipal();
                    }
                }
                else if (entrada == "2")
                {
                    MenuSecundario();

                    var entrada2 = Console.ReadLine();
                    if (entrada2 == "1")
                    {
                        aluno.Cadastrar();
                    }
                    else if (entrada2 == "2")
                    {
                        aluno.ObterTodos(); /*Não exibe no Terminal*/
                    }
                    else if (entrada2 == "3")
                    {
                        aluno.ObterPorID(); /*Não exibe no Terminal*/
                    }
                    else if (entrada2 == "4")
                    {
                        MenuAtualizar();

                        Console.WriteLine("4-Atualizar Turma ");
                        Console.WriteLine("5-Atualizar Periodo de estudo ");
                        Console.WriteLine("6- Voltar ao menu anterior ");
                        Console.WriteLine("7-Voltar ao Menu Principal ");

                        var atualizar = Console.ReadLine();

                        if (atualizar == "1")
                        {
                            aluno.AtualizarNome(aluno.Alunos);
                        }
                        else if (atualizar == "2")
                        {
                            aluno.AtualizarEndereco(aluno.Alunos);
                        }
                        else if (atualizar == "3")
                        {
                            aluno.AtualizarTelefone(aluno.Alunos);
                        }
                        else if (atualizar == "4")
                        {
                            aluno.AtualizarPeriodo(aluno.Alunos);
                        }
                        else if (atualizar == "5")
                        {
                            aluno.AtualizarTurma(aluno.Alunos, turma.Turmas);
                        }
                        else if (atualizar == "6")
                        {
                            MenuSecundario();
                        }
                        else if (atualizar == "7")
                        {
                            MenuPrincipal();
                        }
                    }
                    else if (entrada2 == "5")
                    {
                        aluno.Excluir(turma.Turmas);
                    }
                    else if (entrada2 == "6")
                    {
                        MenuPrincipal();
                    }
                }
                else if (entrada == "3")
                {
                    Console.WriteLine("1- Cadastrar Turma");
                    Console.WriteLine("2- Obter lista de Turmas");
                    Console.WriteLine("3- Pesquisar turma por código");
                    Console.WriteLine("4- Adicionar Aluno na turma");
                    Console.WriteLine("5- Remover Aluno da turma");
                    Console.WriteLine("6- Listar Alunos da turma");
                    Console.WriteLine("7- Adicionar Professor na turma");
                    Console.WriteLine("8- Remover Professor da turma");
                    Console.WriteLine("9- Listar Professores da turma");
                    Console.WriteLine("10- Voltar ao Menu princpal");


                    var entrada2 = Console.ReadLine();

                    if (entrada2 == "1")
                    {
                        turma.Cadastrar(professor.Professores, aluno.Alunos);
                    }
                    else if (entrada2 == "2")
                    {
                        turma.ObterTodos(); /*Não exibe no Terminal*/
                    }
                    else if (entrada2 == "3")
                    {
                        turma.ObterPorID(); /*Não exibe no Terminal*/
                    }
                    else if (entrada2 == "4")
                    {
                        turma.AdicionarAluno(aluno.Alunos);
                    }
                    else if (entrada2 == "5")
                    {
                        turma.RemoverAluno(aluno.Alunos);
                    }
                    else if (entrada2 == "6")
                    {
                        turma.ObterAlunos(aluno.Alunos); /*Não exibe no Terminal*/
                    }
                    else if (entrada2 == "7")
                    {
                        turma.AdicionarProfessor(professor.Professores);
                    }
                    else if (entrada == "8")
                    {
                        turma.RemoverProfessor(professor.Professores);

                    }
                    else if (entrada2 == "9")
                    {
                        turma.ObterProfessores();

                    }
                }
                else if (entrada == "4")
                {
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
