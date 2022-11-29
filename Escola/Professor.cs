using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Escola
{
    public class Professor : Pessoa
    {
        public List<Professor> Professores = new List<Professor>();
        public string materia { get; set; }

        public Professor()
        {
        
        }

        public override void Cadastrar()
        {
            Console.WriteLine("Digite o nome do Professor:");
            var _nome = Console.ReadLine();

            Console.WriteLine("Digite a matrícula do Professor:");
            var _idProf = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o endereço do Professor:");

            Console.WriteLine("Código do endereço:");
            var _cdEndereco = int.Parse(Console.ReadLine());

            Console.WriteLine("Cidade:");
            var _cidade = Console.ReadLine();

            Console.WriteLine("Estado UTF:");
            var _estado = Console.ReadLine();

            var estado =_estado.ToUpper();
            string padraoUTF = "[A-Z]{2}";
            while (true)
            {
                if (Regex.IsMatch(estado, padraoUTF) == false)
                {
                    Console.WriteLine("Estado, UTF inválido!");
                    Console.WriteLine("Ex: SP ");
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

            Console.WriteLine("Cep:");
            var _cep = Console.ReadLine();
            string padraoCep = "[0 - 9]{ 2}[0 - 9]{ 3}[-]{ 0,1}[0 - 9]{ 3}";
            while (true)
            {
                if (Regex.IsMatch(_cep, padraoCep) == false)
                {
                    Console.WriteLine("NÚMERO DE CEP INVÁLIDO!");
                    Console.WriteLine("Ex: XXXXX-XXX");
                }
                else
                {
                    break;
                }
            }
            

            Console.WriteLine("Bairro:");
            var _bairro = Console.ReadLine();

            Console.WriteLine("Digite o telefone do Professor com o DDD:");
            var _telefone = Console.ReadLine();


            string padraoCelular = "[0 - 9]{ 2}[0 - 9]{ 5}[-]{ 0,1}[0 - 9]{ 4}";
            while (true)
            {
                if (Regex.IsMatch(_telefone, padraoCelular) == false)
                {
                    Console.WriteLine("NÚMERO DE TELEFONE INVÁLIDO!");
                    Console.WriteLine("Ex: xxxxxx-xxxx");
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Digite a Matéria de ensino:");
            var _materia = Console.ReadLine();

            
            string telToString = _telefone.Substring(3);
            int transformandoDDD = _telefone.ToString().Length - telToString.Length;
            string ddd = _telefone.Substring(0, 2);

            var telefone = new Telefone { celular =telToString, ddd = ddd };

            var endereco = new Endereco { idEndereco = _cdEndereco, bairro = _bairro, cep = _cep, cidade = _cidade, estadoUTF = _estado, logradouro = _logradouro, numero = _numero };

            var professor = new Professor
            {
                IdPessoa = _idProf,
                Nome = _nome,
                Endereco = endereco,
                Telefone = telefone,
                materia = _materia
            };

            Professores.Add(professor);
        }
        public override object ObterTodos()
        {
            return Professores;
        }
        public override object ObterPorID()
        {
            Console.WriteLine("Digite a matrícula do Professor:");
            var _id = int.Parse(Console.ReadLine());

            var professor = Professores.FirstOrDefault(x => x.IdPessoa == _id);

            return professor;
        }

        public void AtualizarNome(List<Professor> professores)
        {
            Console.WriteLine("Digite o cógigo do Professor: ");
            var cdProfessor = int.Parse(Console.ReadLine());

            var professorEncontrado = professores.FirstOrDefault(x => x.IdPessoa == cdProfessor);

            if (professorEncontrado != null)
            {
                var indice = professores.IndexOf(professorEncontrado);

                Console.WriteLine("Nome atualizado do professor: ");
                var _nomeAtual = Console.ReadLine();

                professores[indice].Nome = _nomeAtual;
            }
            else
            {
                Console.WriteLine("Código do professor não encontrado não encontrado...");
            }
        }

        public void AtualizarEndereco(List<Professor> professores)
        {
            Console.WriteLine("Digite o cógigo do Porfessor: ");
            var cdProfessor = int.Parse(Console.ReadLine());

            var professorEncontrado = professores.FirstOrDefault(x => x.IdPessoa == cdProfessor);

            if (professorEncontrado != null)
            {
                var indice = professores.IndexOf(professorEncontrado);

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

                if (escolha == "1")
                {
                    Console.WriteLine("Digite o Cep: ");
                    var _enderecoAtual = Console.ReadLine();
                    string padraoCep = "[0 - 9]{ 2}[0 - 9]{ 3}[-]{ 0,1}[0 - 9]{ 3}";
                    if (Regex.IsMatch(_enderecoAtual, padraoCep) == false)
                    {
                        Console.WriteLine("NÚMERO DE CEP INVÁLIDO!");
                        Console.WriteLine("Ex: XXXXX-XXX");
                    }
                    professores[indice].Endereco.cep = _enderecoAtual;
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
                        professores[indice].Endereco.estadoUTF = _enderecoAtual;
                    }
                }
                else if (escolha == "3")
                {
                    Console.WriteLine("Digite a cidade: ");
                    var _enderecoAtual = Console.ReadLine();
                    professores[indice].Endereco.cidade = _enderecoAtual;
                }
                else if (escolha == "4")
                {
                    Console.WriteLine("Digite o Bairro: ");
                    var _enderecoAtual = Console.ReadLine();
                    professores[indice].Endereco.bairro = _enderecoAtual;
                }
                else if (escolha == "5")
                {
                    Console.WriteLine("Digite a Rua: ");
                    var _enderecoAtual = Console.ReadLine();
                    professores[indice].Endereco.logradouro = _enderecoAtual;
                }
                else if (escolha == "6")
                {
                    Console.WriteLine("Digite o numero da residencia: ");
                    var _enderecoAtual = int.Parse(Console.ReadLine());
                    professores[indice].Endereco.numero = _enderecoAtual;
                }
                else if (escolha == "7")
                {
                    Console.WriteLine("Digite o código do endereço: ");
                    var _enderecoAtual = int.Parse(Console.ReadLine());
                    professores[indice].Endereco.numero = _enderecoAtual;
                }
                else
                {
                    Console.WriteLine("OPÇÃO INVÁLIDA");
                    
                }
            }
            else
            {
                Console.WriteLine("Código do professor não encontrado não encontrado...");
            }
          
        }

        public void AtualizarTelefone(List<Professor> professores)
        {
            Console.WriteLine("Digite o cógigo do Professor: ");
            var cdProfessor = int.Parse(Console.ReadLine());

            var alunoEncontrado = professores.FirstOrDefault(x => x.IdPessoa == cdProfessor);

            if (alunoEncontrado != null)
            {
                var indice = professores.IndexOf(alunoEncontrado);

                Console.WriteLine("Atualizar telefone ");
                Console.WriteLine();

                Console.WriteLine("1- Atualizar o DDD ");
                Console.WriteLine("2-Atualizar Telfone ");
                var escolha = Console.ReadLine();

                if (escolha == "1")
                {
                    Console.WriteLine("Digite o DDD ");
                    var _telefoneAtual = Console.ReadLine();

                    string padraoCelular = "[0 - 9]{ 2}";
                    if (Regex.IsMatch(_telefoneAtual, padraoCelular) == false)
                    {
                        Console.WriteLine("NÚMERO DO DDD INVÁLIDO!");
                        Console.WriteLine("Ex: xx ");
                    }
                    professores[indice].Telefone.ddd = _telefoneAtual;
                }
                else if (escolha == "2")
                {
                    Console.WriteLine("Digite o celular ");
                    var _telefoneAtual = Console.ReadLine();

                    string padraoCelular = "[0 - 9]{ 5}[-]{ 0,1}[0 - 9]{ 4}";
                    if (Regex.IsMatch(_telefoneAtual, padraoCelular) == false)
                    {
                        Console.WriteLine("NÚMERO DE TELEFONE INVÁLIDO!");
                        Console.WriteLine("Ex: XXXXXXX-XXXX");
                    }

                    professores[indice].Telefone.celular = _telefoneAtual;
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
        
        public void AtualizarMateria(List<Professor> professores)
        {
            Console.WriteLine("Digite o cógigo do Professor: ");
            var cdProfessor = int.Parse(Console.ReadLine());

            var professorEncontrado = professores.FirstOrDefault(x => x.IdPessoa == cdProfessor);

            if (professorEncontrado != null)
            {
                var indice = professores.IndexOf(professorEncontrado);

                Console.WriteLine("Atual Matéria aplicada pelo professor: ");
                var _materiaAtual = Console.ReadLine();

                professores[indice].materia = _materiaAtual;
            }
            else
            {
                Console.WriteLine("Código do professor não encontrado não encontrado...");
            }
        }
        public void Excluir(List<Turma> turmas)
        {
            Console.WriteLine("Digite o código do professor para removê-lo ");
            var matricula = int.Parse(Console.ReadLine());

            var professorEncontrado = Professores.FirstOrDefault(x => x.IdPessoa == matricula);
            if (professorEncontrado != null)
            {
                //var indice = Professores.IndexOf(professorEncontrado);
                if (Professores.Contains(professorEncontrado))
                {
                    professorEncontrado.Professores.Remove(professorEncontrado);
                }
                else
                {
                    Console.WriteLine("O professor está cadastrado em uma turma");
                }
            }
            else
            {
                Console.WriteLine("Código do professor não encontrado...");
            }
        }
    }
}
