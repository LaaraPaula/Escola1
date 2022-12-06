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

        public string msg = "Código do professor não encontrado...";

        public Professor()
        {

        }

        public override void Cadastrar()
        {
            var _nome = "";
            while (true)
            {
                Console.WriteLine("Digite o nome do Professor:");
                _nome = Console.ReadLine();
                if (!Regex.IsMatch(_nome, @"^[a-zA-Z\x20]+$"))
                {
                    Console.WriteLine("Digite apenas letras para o nome do Professor");
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine();
            var _idProf = 0;

            while (true)
            {
                Console.WriteLine("Digite o código do professor:");
                var idProfStr = Console.ReadLine();

                if (!Regex.IsMatch(idProfStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _idProf = int.Parse(idProfStr);
                    var existeProfessor = Professores.Any(x => x.IdPessoa == _idProf);
                    if (!existeProfessor)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Código do Professor já EXISTE!!");
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("\n------Endereço------\n");

            var _cdEndereco = 0;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Código do endereço:");
                var _cdEnderecoStg = Console.ReadLine();

                if (!Regex.IsMatch(_cdEnderecoStg, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _cdEndereco = int.Parse(_cdEnderecoStg);
                    break;
                }
            }
            Console.WriteLine();
            var _cidade = "";
            while (true)
            {
                Console.WriteLine("Cidade:");
                _cidade = Console.ReadLine();
                if (!Regex.IsMatch(_cidade, @"^[a-zA-Z\x20]+$"))
                {
                    Console.WriteLine("Digite apenas letras para o nome da cidade");
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine();
            string _estado = "";
            while (true)
            {
                Console.WriteLine("Digite Estado UF:");
                _estado = Console.ReadLine();
                var estado = _estado.ToUpper();
                const string padraoUF = "^[A-T]{2}$";

                Match resultado = Regex.Match(estado, padraoUF);


                if (String.IsNullOrEmpty(resultado.ToString()))
                {
                    Console.WriteLine("Estado, UTF inválido!");
                    Console.WriteLine("Ex: SP ");
                    Console.WriteLine();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Logradouro:");
            var _logradouro = Console.ReadLine();

            Console.WriteLine();
            var _numero = 0;
            while (true)
            {
                Console.WriteLine("Numero:");
                var _numeroStg = Console.ReadLine();
                if (Regex.IsMatch(_numeroStg,@"^[0-9]+$"))
                {
                    _numero = int.Parse(_numeroStg);
                    break;
                }
                else
                {
                    Console.WriteLine("O número da residencia não pode letras nem decimais, somente número inteiro. ");
                }
            }
            Console.WriteLine();

            string _cep = "";
            while (true)
            {
                Console.WriteLine("Cep:");
                _cep = Console.ReadLine();
                string padraoCep = @"^\d{5}[-]?\d{3}$";

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

            Console.WriteLine();
            Console.WriteLine("Bairro:");
            var _bairro = Console.ReadLine();

            Console.WriteLine();
            string _telefone = "";
            while (true)
            {
                Console.WriteLine("Digite o telefone do professor com o DDD:");
                _telefone = Console.ReadLine();

                string padraoCelular = @"^\d{6,7}[-]?\d{4}$";
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

            Console.WriteLine();
            Console.WriteLine("Digite a Matéria de ensino:");
            var _materia = Console.ReadLine();
            Console.WriteLine();

            string telToString = _telefone.Substring(3);
            string ddd = _telefone.Substring(0, 2);

            var telefone = new Telefone { celular = telToString, ddd = ddd };

            var endereco = new Endereco { idEndereco = _cdEndereco, bairro = _bairro.ToUpper(), cep = _cep, cidade = _cidade.ToUpper(), estadoUF = _estado, logradouro = _logradouro.ToUpper(), numero = _numero };

            var professor = new Professor
            {
                IdPessoa = _idProf,
                Nome = _nome.ToUpper(),
                Endereco = endereco,
                Telefone = telefone,
                materia = _materia.ToUpper()
            };
            Professores.Add(professor);
            Console.WriteLine("Professor Cadastrado com sucesso!!");
            Console.WriteLine("==================================================");
        }
        public override void ObterTodos()
        {
            var listaOrdenada = Professores.OrderBy(c => c.Nome).ToList();
            foreach (var item in listaOrdenada)
            {
                Console.WriteLine($"Nome: {item.Nome}\tMateria: {item.materia}\tID: {item.IdPessoa}");
             
            }
            if (listaOrdenada.Count == 0)
            {
                Console.WriteLine("Não existe nenhum professor cadastrado!");
            }
            Console.WriteLine();
        }
        public override void ObterPorID()
        {
            var _id = 0;
            while (true)
            {
                Console.WriteLine("Digite o código do professor:");
                var _profStr = Console.ReadLine();
                if (!Regex.IsMatch(_profStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _id = int.Parse(_profStr);

                    var professor = Professores.FirstOrDefault(x => x.IdPessoa == _id);
                    if (professor != null)
                    {
                        Console.WriteLine($"Nome: {professor.Nome}\tMateria: {professor.materia}\tID: {professor.IdPessoa}");
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
        public void AtualizarNome(List<Professor> professores)
        {
            var _id = 0;
            while (true)
            {
                Console.WriteLine("Digite o código do professor:");
                var _profStr = Console.ReadLine();
                if (!Regex.IsMatch(_profStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _id = int.Parse(_profStr);

                    var professorEncontrado = professores.FirstOrDefault(x => x.IdPessoa == _id);

                    if (professorEncontrado != null)
                    {
                        while (true)
                        {
                            var indice = professores.IndexOf(professorEncontrado);

                            Console.WriteLine("Nome atualizado do professor: ");
                            var _nomeAtual = Console.ReadLine();
                            if (Regex.IsMatch(_nomeAtual, @"^[a-zA-Z\x20]+$"))
                            {
                                Console.WriteLine($"Nome do(a) professor(a) {professorEncontrado.Nome} atualizado(a) com sucesso.");
                                professores[indice].Nome = _nomeAtual.ToUpper();
                                Console.WriteLine($"Nome atual é: {professorEncontrado.Nome} ");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Digine apenas letras para o Nome");
                                break;
                            }
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Código do professor não encontrado não encontrado...");
                        break;
                    }
                }
                break;
            }
            Console.WriteLine();
        }
        public void AtualizarEndereco(List<Professor> professores)
        {
            var _id = 0;
            while (true)
            {
                Console.WriteLine("Digite o código ddo professor:");
                var _profStr = Console.ReadLine();
                if (!Regex.IsMatch(_profStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _id = int.Parse(_profStr);

                    var professorEncontrado = professores.FirstOrDefault(x => x.IdPessoa == _id);

                    if (professorEncontrado != null)
                    {
                        var indice = professores.IndexOf(professorEncontrado);

                        Console.WriteLine("Atualizar endereco");
                        Console.WriteLine();
                        Console.WriteLine("1- CEP");
                        Console.WriteLine("2- Estado UF");
                        Console.WriteLine("3- Cidade");
                        Console.WriteLine("4- Bairro");
                        Console.WriteLine("5- Logradouro");
                        Console.WriteLine("6- Número da Residência");



                        var escolha = Console.ReadLine();

                        if (escolha == "1")
                        {
                            Console.WriteLine("Digite o Cep: ");
                            var _enderecoAtual = Console.ReadLine();
                            string padraoCep = @"^\d{5}[-]?\d{3}$";
                            if (Regex.IsMatch(_enderecoAtual, padraoCep) == false)
                            {
                                Console.WriteLine("NÚMERO DE CEP INVÁLIDO!");
                                Console.WriteLine("Ex: XXXXX-XXX");
                            }
                            else
                            {
                                professores[indice].Endereco.cep = _enderecoAtual;
                                Console.WriteLine($"Cep do(a) professor(a) {professorEncontrado.Nome} atualizada com sucesso.");
                            }
                        }
                        else if (escolha == "2")
                        {
                            string _enderecoAtual = "";
                            while (true)
                            {
                                Console.WriteLine("Digite Estado UF:");
                                _enderecoAtual = Console.ReadLine();
                                var estado = _enderecoAtual.ToUpper();
                                const string padraoUF = "^[A-T]{2}$";

                                Match resultado = Regex.Match(estado, padraoUF);


                                if (String.IsNullOrEmpty(resultado.ToString()))
                                {
                                    Console.WriteLine("Estado, UF inválido!");
                                    Console.WriteLine("Ex: SP ");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Professores[indice].Endereco.estadoUF = _enderecoAtual.ToUpper();
                                    Console.WriteLine($"Estado do(a) professor(a) {professorEncontrado.Nome} atualizada com sucesso.");
                                    break;
                                }
                            }
                        }
                        else if (escolha == "3")
                        {
                            var _enderecoAtual = "";
                            while (true)
                            {
                                Console.WriteLine("Cidade Atual:");
                                _enderecoAtual = Console.ReadLine();
                                if (!Regex.IsMatch(_enderecoAtual, @"^[a-zA-Z\x20]+$"))
                                {
                                    Console.WriteLine("Digite apenas letras para o nome da cidade");
                                }
                                else
                                {
                                    professores[indice].Endereco.cidade = _enderecoAtual.ToUpper();
                                    Console.WriteLine($"Cidade do(a) professor(a) {professorEncontrado.Nome} atualizada com sucesso.");
                                    break;
                                }
                            }
                        }
                        else if (escolha == "4")
                        {
                            Console.WriteLine("Digite o Bairro: ");
                            var _enderecoAtual = Console.ReadLine();
                            professores[indice].Endereco.bairro = _enderecoAtual.ToUpper();
                            Console.WriteLine($"Bairro do(a) professor(a) {professorEncontrado.Nome} atualizada com sucesso.");
                        }
                        else if (escolha == "5")
                        {
                            Console.WriteLine("Digite a Rua: ");
                            var _enderecoAtual = Console.ReadLine();
                            professores[indice].Endereco.logradouro = _enderecoAtual.ToUpper();
                            Console.WriteLine($"Rua do(a) professor(a) {professorEncontrado.Nome} atualizada com sucesso.");
                        }
                        else if (escolha == "6")
                        {
                            var _numeroAtual = 0;
                            while (true)
                            {
                                Console.WriteLine("Numero:");
                                var _numeroStg = Console.ReadLine();
                                if (Regex.IsMatch(_numeroStg, @"^[0-9]+$"))
                                {
                                    _numeroAtual = int.Parse(_numeroStg);
                                    professores[indice].Endereco.numero = _numeroAtual;
                                    Console.WriteLine($"Telefone do professor {professorEncontrado.Nome} atualizada com sucesso.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("O número da residencia não pode letras nem decimais, somente número inteiro. ");
                                }
                            
                            }
                        }
                        else
                        {
                            Console.WriteLine("OPÇÃO INVÁLIDA");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine(msg);
                        break;
                    }
                    
                }
                break;
            }
            Console.WriteLine();

        }
        public void AtualizarTelefone(List<Professor> professores)
        {
            var _id = 0;
            while (true)
            {
                Console.WriteLine("Digite o código do professor:");
                var _profStr = Console.ReadLine();
                if (!Regex.IsMatch(_profStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _id = int.Parse(_profStr);

                    var professorEncontrado = Professores.FirstOrDefault(x => x.IdPessoa == _id);

                    if (professorEncontrado != null)
                    {
                        var indice = Professores.IndexOf(professorEncontrado);

                        Console.WriteLine("Atualizar telefone ");
                        Console.WriteLine();
                        string _telefoneAtual = "";
                        while (true)
                        {
                            Console.WriteLine("Digite o Teleone:");
                            _telefoneAtual = Console.ReadLine();

                            string padraoCelular = @"^\d{6,7}[-]?\d{4}$";
                            Match resultado = Regex.Match(_telefoneAtual, padraoCelular);

                            if (String.IsNullOrEmpty(resultado.ToString()))
                            {
                                Console.WriteLine("NÚMERO DE TELEFONE INVÁLIDO!");
                                Console.WriteLine("Ex: xxxxxx-xxxx");
                            }
                            else
                            {
                                string telToString = _telefoneAtual.Substring(3, 10);

                                string ddd = _telefoneAtual.Substring(0, 2);

                                var telefone = new Telefone { ddd = ddd, celular = telToString };
                                Professores[indice].Telefone = telefone;
                                Console.WriteLine($"Telefone do(a) professor(a) {professorEncontrado.Nome} atualizada com sucesso.");
                                break;
                            }
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine(msg);
                        break;
                    }
                }
                break;
            }
            Console.WriteLine();
        }
        public void AtualizarMateria(List<Professor> professores)
        {
            var _id = 0;
            while (true)
            {
                Console.WriteLine("Digite o código do professor:");
                var _profStr = Console.ReadLine();
                if (!Regex.IsMatch(_profStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _id = int.Parse(_profStr);

                    var professorEncontrado = professores.FirstOrDefault(x => x.IdPessoa == _id);

                    if (professorEncontrado != null)
                    {
                        var indice = professores.IndexOf(professorEncontrado);

                        Console.WriteLine("Atual Matéria aplicada pelo professor: ");
                        var _materiaAtual = Console.ReadLine();

                        professores[indice].materia = _materiaAtual.ToUpper();
                        Console.WriteLine($"Matéria do(a) professor(a) {professorEncontrado.Nome} atualizada com sucesso.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine(msg);
                        break;
                    }
                }
                break;
            }
            Console.WriteLine();
        }
        public override void Excluir(List<Turma> turmas)
        {
            var _id = 0;
            while (true)
            {
                Console.WriteLine("Digite o código do professor:");
                var _profStr = Console.ReadLine();
                if (!Regex.IsMatch(_profStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _id = int.Parse(_profStr);

                    var professorEncontrado = Professores.FirstOrDefault(x => x.IdPessoa == _id);
                    if (professorEncontrado != null)
                    {
                        var turmaEncontrada = turmas.FirstOrDefault(x => x.Professores.Contains(professorEncontrado));
                        if (turmaEncontrada != null)
                        {
                            Console.WriteLine("O professor está cadastrado em uma turma.\nDeseja realmete excluí-lo da turma e da lista de Professores?");
                            Console.WriteLine("============1-SIM       2-NÃO, Somente da Turma.");
                            var escolha = Console.ReadLine();
                            if (escolha == "1")
                            {
                                turmaEncontrada.Professores.Remove(professorEncontrado);
                                Console.WriteLine($"Professor(a) removido(a) da turma..Id:{turmaEncontrada} com sucesso!");
                                Professores.Remove(professorEncontrado);
                                Console.WriteLine("Professor removido da lista de professores com sucesso!");
                            }
                            else if (escolha == "2")
                            {
                                turmaEncontrada.Professores.Remove(professorEncontrado);
                                Console.WriteLine($"Professor(a) removido(a) da turma..Id:{turmaEncontrada} com sucesso!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("O(a) professor(a) não está cadatrado em nenhuma turma..");
                            Professores.Remove(professorEncontrado);
                            Console.WriteLine("Professor(a) removido(a) da lista de professores com sucesso!");
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine(msg);
                        break;
                    }
                }
                break;
            }
            Console.WriteLine();

        }
        public override void Cadastrar(List<Turma> turmas)
        {
            throw new NotImplementedException();
        }
    }
}
