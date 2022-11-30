using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Escola
{
    public class Aluno : Pessoa
    {
        public List<Aluno> Alunos = new List<Aluno>();
        public string Periodo { get; set; }
        public int IdDaTurma { get; set; }
        public Endereco _estado { get; set; }
        public Endereco _cep { get; set; }
        public Telefone _telefone { get; set;}

        public Aluno()
        { 
            
        }
        public override void Cadastrar()
        {
            Console.WriteLine("Digite o nome do aluno:");
            var _nome = Console.ReadLine();

            Console.WriteLine("Digite a matrícula do aluno:");
            var _idAluno = int.Parse (Console.ReadLine());

            Console.WriteLine("Digite o endereço do aluno:");

            Console.WriteLine("Código do endereço:");
            var _cdEndereco = int.Parse(Console.ReadLine());

            Console.WriteLine("Cidade:");
            var _cidade = Console.ReadLine();

                    //não terminei essa condição entrada do menu 
            
            while (true)
            {
                Console.WriteLine("Digite Estado UTF:");
                var _estado = Console.ReadLine();
                var estado = _estado.ToUpper();
                string padraoUTF = "[A-T]{2}";

                Match resultado = Regex.Match(estado, padraoUTF);
                
                if (String.IsNullOrEmpty(resultado.ToString()))
                {
                    Console.WriteLine("Estado, UTF inválido!");
                    Console.WriteLine("Ex: SP ");
                    Console.WriteLine();
                    Console.WriteLine("Digite Estado UTF:");
                    var _estado2 = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Logradouro:");
            var _logradouro = Console.ReadLine();

            Console.WriteLine("numero:");
            var _numero = int.Parse(Console.ReadLine());

            
            while (true)
            {
                Console.WriteLine("Cep:");
                var _cep = Console.ReadLine();
                string padraoCep = "[0 - 9]{ 2}[0 - 9]{ 3}[-]{0,1}[0 - 9]{ 3}";

                Match resultado = Regex.Match(_cep, padraoCep);

                if (String.IsNullOrEmpty(resultado.ToString()))
                {
                    Console.WriteLine("NÚMERO DE CEP INVÁLIDO!");
                    Console.WriteLine("Ex: XXXXX-XXX");
                    Console.WriteLine();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Bairro:");
            var _bairro = Console.ReadLine();

            
            while (true)
            {
                Console.WriteLine("Digite o telefone do aluno com o DDD:");
                var _telefone = Console.ReadLine();

                string padraoCelular = "[0 - 9]{ 2}[0 - 9]{ 5}[-]{ 0,1}[0 - 9]{ 4}";
                Match resultado = Regex.Match(_telefone, padraoCelular);

                if (String.IsNullOrEmpty(resultado.ToString()))
                {
                    Console.WriteLine("NÚMERO DE TELEFONE INVÁLIDO!");
                    Console.WriteLine("Ex: xxxxxx-xxxx");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Digite o período de estudo do aluno:");
            var _periodo = Console.ReadLine();

            Console.WriteLine("Digite o código da turma do aluno:");
            var _turma = int.Parse(Console.ReadLine());

            string telToString = _telefone.Substring(3,10);
            
            string ddd = _telefone.Substring(0, 2);

            var telefone = new Telefone {ddd = ddd, celular = telToString};

            var endereco = new Endereco {idEndereco = _cdEndereco, bairro= _bairro, cep=_cep , cidade= _cidade , estadoUTF= _estado , logradouro=_logradouro , numero= _numero};

            var aluno = new Aluno
            {
                IdPessoa = _idAluno,
                Nome = _nome,
                Endereco = endereco,
                Telefone = telefone,
                IdDaTurma = _turma
            };

            Alunos.Add(aluno);
            

        }
        public override object ObterTodos()
        {
           return Alunos;
        }
        public override object ObterPorID()
        {
            Console.WriteLine("Digite a matrícula do Aluno:");
            var _id = int.Parse(Console.ReadLine());

            var alunos = Alunos.FirstOrDefault(x => x.IdPessoa == _id);

            return alunos;
        }
        public void AtualizarNome(List<Aluno> alunos)
        {
            Console.WriteLine("Digite o cógigo do Aluno: ");
            var cdAluno = int.Parse(Console.ReadLine());

            var alunoEncontrado = alunos.FirstOrDefault(x => x.IdPessoa == cdAluno);

            if (alunoEncontrado != null)
            {
                var indice = alunos.IndexOf(alunoEncontrado);

                Console.WriteLine("Nome atualizado do aluno: ");
                var _nomeAtual = Console.ReadLine();

                alunos[indice].Nome = _nomeAtual;
            }
            else
            {
                Console.WriteLine("Código do aluno não encontrado não encontrado");
            }
        }

        public void AtualizarEndereco(List<Aluno> alunos)
        {
            Console.WriteLine("Digite o cógigo do Aluno: ");
            var cdAluno = int.Parse(Console.ReadLine());

            var alunoEncontrado = alunos.FirstOrDefault(x => x.IdPessoa == cdAluno);

            if (alunoEncontrado != null)
            {
                var indice = alunos.IndexOf(alunoEncontrado);

                Console.WriteLine("Atualizar endereco");
                Console.WriteLine();
                Console.WriteLine("1- CEP");
                Console.WriteLine("2- Estado UTF");
                Console.WriteLine("3- Cidade");
                Console.WriteLine("4- Bairro");
                Console.WriteLine("5- Logradouro");
                Console.WriteLine("6- Número da Residência");
                Console.WriteLine("7- Código do endereço");


                var escolha = Console.ReadLine();

                if (escolha =="1")
                {
                    Console.WriteLine("Digite o Cep: ");
                    var _enderecoAtual = Console.ReadLine();
                    alunos[indice].Endereco.cep = _enderecoAtual;
                }
                else if (escolha == "2")
                {
                    Console.WriteLine("Digite o Estado (UTF): ");
                    var _enderecoAtual = Console.ReadLine();

                    _enderecoAtual.ToUpper();
                    string padraoUTF = "[A-Z]{2}";
                    if (Regex.IsMatch(_enderecoAtual, padraoUTF) == false)
                    {
                        Console.WriteLine("Estado, UTF inválido!");
                        Console.WriteLine("Ex: SP ");
                    }
                    else
                    {
                        alunos[indice].Endereco.estadoUTF = _enderecoAtual;
                    }
                    
                }
                else if (escolha == "3")
                {
                    Console.WriteLine("Digite a cidade: ");
                    var _enderecoAtual = Console.ReadLine();
                    alunos[indice].Endereco.cidade = _enderecoAtual;
                }
                else if (escolha == "4")
                {
                    Console.WriteLine("Digite o Bairro: ");
                    var _enderecoAtual = Console.ReadLine();
                    alunos[indice].Endereco.bairro = _enderecoAtual;
                }
                else if (escolha == "5")
                {
                    Console.WriteLine("Digite a Rua: ");
                    var _enderecoAtual = Console.ReadLine();
                    alunos[indice].Endereco.logradouro = _enderecoAtual;
                }
                else if (escolha == "6")
                {
                    Console.WriteLine("Digite o numero da residencia: ");
                    var _enderecoAtual = int.Parse(Console.ReadLine());
                    alunos[indice].Endereco.numero = _enderecoAtual;
                }
                else if (escolha == "7")
                {
                    Console.WriteLine("Digite o código do endereço: ");
                    var _enderecoAtual = int.Parse(Console.ReadLine());
                    alunos[indice].Endereco.numero = _enderecoAtual;
                }

            }
            else
            {
                Console.WriteLine("Código do aluno não encontrado não encontrado");
            }
        }

        public void  AtualizarTelefone(List<Aluno> alunos)
        {
            Console.WriteLine("Digite o cógigo do Aluno: ");
            var cdAluno = int.Parse(Console.ReadLine());

            var alunoEncontrado = alunos.FirstOrDefault(x => x.IdPessoa == cdAluno);

            if (alunoEncontrado != null)
            {
                var indice = alunos.IndexOf(alunoEncontrado);

                Console.WriteLine("Atualizar telefone ");
                Console.WriteLine();

                Console.WriteLine("1- Atualizar o DDD ");
                Console.WriteLine("2-Atualizar Telfone ");
                var escolha = Console.ReadLine();

                if(escolha=="1")
                {
                    Console.WriteLine("Digite o DDD ");
                    var _telefoneAtual = Console.ReadLine();
                    string padraoCelular = "[0 - 9]{ 2}";
                    if (Regex.IsMatch(_telefoneAtual, padraoCelular) == false)
                    {
                        Console.WriteLine("NÚMERO DO DDD INVÁLIDO!");
                        Console.WriteLine("Ex: xx");
                    }
                    alunos[indice].Telefone.ddd = _telefoneAtual;
                }
                else if (escolha=="2")
                {
                    Console.WriteLine("Digite o celular ");
                    var _telefoneAtual = Console.ReadLine();

                    string padraoCelular = "[0 - 9]{ 5}[-]{ 0,1}[0 - 9]{ 4}";
                    if (Regex.IsMatch(_telefoneAtual, padraoCelular) == false)
                    {
                        Console.WriteLine("NÚMERO DE TELEFONE INVÁLIDO!");
                        Console.WriteLine("Ex: XXXXXXX-XXXX");
                    }

                    alunos[indice].Telefone.ddd = _telefoneAtual;
                }
                else
                {
                    Console.WriteLine("OPÇÃO INVÁLIDA");
                }
                
            }
            else
            {
                Console.WriteLine("Código do aluno não encontrado não encontrado...");
            }
        }
        public void AtualizarPeriodo(List<Aluno> alunos)
        {
            Console.WriteLine("Digite o cógigo do Aluno: ");
            var cdAluno = int.Parse(Console.ReadLine());

            var alunoEncontrado = alunos.FirstOrDefault(x => x.IdPessoa == cdAluno);

            if (alunoEncontrado != null)
            {
                var indice = alunos.IndexOf(alunoEncontrado);

                Console.WriteLine("Qual periodo de estudo atual do aluno: ");
                var _periodoAtual = Console.ReadLine();

                alunos[indice].Periodo = _periodoAtual;
            }
            else
            {
                Console.WriteLine("Código do aluno não encontrado não encontrado...");
            }
        }
        public void AtualizarTurma(List<Aluno> alunos, List<Turma> turmas)
        {
            Console.WriteLine("Digite o cógigo do Aluno: ");
            var cdAluno = int.Parse(Console.ReadLine());

            var alunoEncontrado = alunos.FirstOrDefault(x => x.IdPessoa == cdAluno);

            if (alunoEncontrado != null)
            {
                var indice = alunos.IndexOf(alunoEncontrado);

                Console.WriteLine("Qual a turma atual do aluno: ");
                var _turmaAtual = int.Parse(Console.ReadLine());

                var turmaEncontrada = turmas.FirstOrDefault(x => x.IdTurma == _turmaAtual);

                if (turmaEncontrada != null)
                {
                    alunos[indice].IdDaTurma = _turmaAtual;
                }
                else
                {
                    Console.WriteLine("Código da turma não encontrado não encontrado...");
                }
            }
            else
            {
                Console.WriteLine("Código do aluno não encontrado não encontrado...");
            }
        }
        public void Excluir(List<Turma> turmas)
        {
            Console.WriteLine("Digite a matrícula do aluno removê-lo ");
            var matricula = int.Parse(Console.ReadLine());

            var alunoEncontrado = Alunos.FirstOrDefault(x => x.IdPessoa == matricula);
            if (alunoEncontrado != null)
            {
                alunoEncontrado.Alunos.Remove(alunoEncontrado);
                alunoEncontrado.IdDaTurma=0;
            }
            else
            {
                Console.WriteLine("Código do aluno não encontrado...");
            }
            
        }
    }

}
