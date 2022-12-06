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
        public Telefone _telefone { get; set; }

        public string msg = "Código do aluno não encontrado";

        public Aluno(int idPessoa, string nome, Telefone telefone, Endereco endereco) : base(idPessoa, nome, telefone, endereco)
        {

        }
        public Aluno()
        {

        }
        public override void Cadastrar(List<Turma> turmas)
        {
            var _nome = "";
            while (true)
            {
                Console.WriteLine("Digite o nome do aluno:");
                _nome = Console.ReadLine();
                if (!Regex.IsMatch(_nome , @"^[a-zA-Z\x20]+$"))
                {
                    Console.WriteLine("Digite apenas letras para o nome do aluno");
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine();
            var _idAluno = 0;
            
            while (true)
            {
                Console.WriteLine("Digite a matrícula do aluno:");
                var idAlunoStr = Console.ReadLine();

                if (!Regex.IsMatch(idAlunoStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _idAluno = int.Parse(idAlunoStr);
                    var existeAluno = Alunos.Any(x => x.IdPessoa == _idAluno);
                    if (!existeAluno)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Código do Aluno já EXISTE!!");
                        Console.WriteLine();
                    }
                }
            }
            
            Console.WriteLine();


            Console.WriteLine("\n------Endereço------\n");
            Console.WriteLine();
            var _cdEndereco = 0;
            while (true)
            {
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
                    Console.WriteLine("Estado, UF inválido!");
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
                if (Regex.IsMatch(_numeroStg, @"^[0-9]+$"))
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
                Console.WriteLine("Digite o telefone do aluno com o DDD:");
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
            Console.WriteLine("Digite o período de estudo do aluno:");
            var _periodo = Console.ReadLine();

            string telToString = _telefone.Substring(3);

            string ddd = _telefone.Substring(0, 2);

            var telefone = new Telefone { ddd = ddd, celular = telToString };

            var endereco = new Endereco { idEndereco = _cdEndereco, bairro = _bairro.ToUpper(), cep = _cep, cidade = _cidade.ToUpper(), estadoUF = _estado, logradouro = _logradouro.ToUpper(), numero = _numero };

            var aluno = new Aluno
            {
                IdPessoa = _idAluno,
                Nome = _nome.ToUpper(),
                Endereco = endereco,
                Telefone = telefone,
                Periodo = _periodo.ToUpper()
            };

            var _turma = 0;
            
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Digite o código da turma do aluno:");
                var _turmaStr = Console.ReadLine();
                if (!Regex.IsMatch(_turmaStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    _turma = int.Parse(_turmaStr);

                    var turmaEncontrada = turmas.FirstOrDefault(x => x.IdTurma == _turma);

                    if (turmaEncontrada != null)
                    {
                        aluno.IdDaTurma = _turma;
                        Alunos.Add(aluno);
                        Console.WriteLine("Aluno Cadastrado com sucesso!!");
                        Console.WriteLine("==================================================");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Código de turma não existe no registro");
                    }
                }
            }
            Console.WriteLine();


        }
        public override void ObterTodos()
        {
            var listaOrdenada = Alunos.OrderBy(c => c.Nome).ToList();
            foreach (var item in listaOrdenada)
            {
                Console.WriteLine($"Nome: {item.Nome}\tPeriodo: {item.Periodo}\tID: {item.IdPessoa}");
 
            }
            if (listaOrdenada.Count==0)
            {
                Console.WriteLine("Não existe nenhum aluno cadastrado!");
            }
            Console.WriteLine();
        }
        public override void ObterPorID()
        {
            var _id = 0;
            while (true)
            {
                Console.WriteLine("Digite a matrícula do Aluno:");
                var _idStr = Console.ReadLine();

                if (!Regex.IsMatch(_idStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Cóigo aceita apenas numero");
                }
                else
                {
                    _id = int.Parse(_idStr);

                    var aluno = Alunos.FirstOrDefault(x => x.IdPessoa == _id);
                    if (aluno != null)
                    {
                        Console.WriteLine($"Nome: {aluno.Nome}\tPeriodo: {aluno.Periodo}\tID: {aluno.IdPessoa}");
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
        public void AtualizarNome(List<Aluno> alunos)
        {
            while(true)
            {
                Console.WriteLine("Digite o cógigo do Aluno: ");
                var _cdAlunoStr = (Console.ReadLine());

                if (!Regex.IsMatch(_cdAlunoStr, @"^[0-9]+$"))
                {
                    Console.WriteLine("Código aceita apenas números");
                }
                else
                {
                    var cdAluno = int.Parse(_cdAlunoStr);
                    var alunoEncontrado = alunos.FirstOrDefault(x => x.IdPessoa == cdAluno);

                    if (alunoEncontrado != null)
                    {
                        var indice = alunos.IndexOf(alunoEncontrado);
                        while (true)
                        {
                            Console.WriteLine("Nome atualizado do aluno: ");
                            var _nomeAtual = Console.ReadLine();
                            if (Regex.IsMatch(_nomeAtual, @"^[a-zA-Z\x20]+$"))
                            {
                                
                                Console.WriteLine($"Nome do(a) aluno(a) {alunoEncontrado.Nome} atualizado com sucesso!");
                                alunos[indice].Nome = _nomeAtual.ToUpper();
                                Console.WriteLine($"Nome atual é: {alunoEncontrado.Nome} ");
                                break;
                                
                            }
                            else
                            {
                                Console.WriteLine("Digite apenas letras para o nome do aluno");
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Código do aluno não encontrado não encontrado");
                        break;
                    }
                }
            }
            Console.WriteLine();
        }
        public void AtualizarEndereco(List<Aluno> alunos)
        {
            var _id = 0;
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
                    _id = int.Parse(_idAlunoStr);

                    var alunoEncontrado = alunos.FirstOrDefault(x => x.IdPessoa == _id);

                    if (alunoEncontrado != null)
                    {
                        var indice = alunos.IndexOf(alunoEncontrado);

                        Console.WriteLine("-------Atualizar endereco-------");
                        Console.WriteLine();
                        Console.WriteLine("1- CEP");
                        Console.WriteLine("2- Estado UF");
                        Console.WriteLine("3- Cidade");
                        Console.WriteLine("4- Bairro");
                        Console.WriteLine("5- Logradouro");
                        Console.WriteLine("6- Número da Residência");
                        Console.WriteLine();

                        var escolha = Console.ReadLine();

                        if (escolha == "1")
                        {
                            string _enderecoAtual = "";
                            while (true)
                            {
                                Console.WriteLine("Cep:");
                                _enderecoAtual = Console.ReadLine();
                                string padraoCep = @"^\d{5}[-]?\d{3}$";

                                Match resultado = Regex.Match(_enderecoAtual, padraoCep);

                                if (String.IsNullOrEmpty(resultado.ToString()))
                                {
                                    Console.WriteLine("NÚMERO DE CEP INVÁLIDO!");
                                    Console.WriteLine("Ex: XXXXX-XXX");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    alunos[indice].Endereco.cep = _enderecoAtual.ToUpper();
                                    Console.WriteLine($"Cep do(a) aluno(a) {alunoEncontrado.Nome} atualizado com sucesso");
                                    break;
                                }
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
                                    alunos[indice].Endereco.estadoUF = _enderecoAtual.ToUpper();
                                    Console.WriteLine($"Estado do(a) aluno(a) {alunoEncontrado.Nome} atualizado com sucesso");
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
                                    alunos[indice].Endereco.cidade = _enderecoAtual.ToUpper();
                                    Console.WriteLine($"Cidade do(a) aluno(a) {alunoEncontrado.Nome} atualizado com sucesso");
                                    break;
                                }
                            }
                        }
                        else if (escolha == "4")
                        {
                            Console.WriteLine("Digite o Bairro: ");
                            var _enderecoAtual = Console.ReadLine();
                            alunos[indice].Endereco.bairro = _enderecoAtual.ToUpper();
                            Console.WriteLine($"Bairro do(a) aluno(a) {alunoEncontrado.Nome} atualizado com sucesso");
                        }
                        else if (escolha == "5")
                        {
                            Console.WriteLine("Digite a Rua: ");
                            var _enderecoAtual = Console.ReadLine();
                            alunos[indice].Endereco.logradouro = _enderecoAtual.ToUpper();
                            Console.WriteLine($"Rua do(a) aluno(a) {alunoEncontrado.Nome} atualizado com sucesso");
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
                                    alunos[indice].Endereco.numero = _numeroAtual;
                                    Console.WriteLine($"Número da residencia do(a) aluno(a) {alunoEncontrado.Nome} atualizado com sucesso");
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
                            Console.WriteLine("OPÇÃO INVÁLIDA!!");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Código do aluno não encontrado não encontrado");
                        break;
                    }
                }
                
            }
            Console.WriteLine();
        }
        public void AtualizarTelefone(List<Aluno> alunos)
        {
            var _id = 0;
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
                    _id = int.Parse(_idAlunoStr);

                    var alunoEncontrado = alunos.FirstOrDefault(x => x.IdPessoa == _id);

                    if (alunoEncontrado != null)
                    {
                        var indice = alunos.IndexOf(alunoEncontrado);

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
                                alunos[indice].Telefone = telefone;
                                Console.WriteLine($"Telefone do(a) aluno(a) {alunoEncontrado.Nome} atualizado com sucesso");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Código do aluno não encontrado não encontrado...");
                        break;
                    }
                }
                
            }
            Console.WriteLine();

        }
        public void AtualizarPeriodo(List<Aluno> alunos)
        {
            var _id = 0;
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
                    _id = int.Parse(_idAlunoStr);

                    var alunoEncontrado = alunos.FirstOrDefault(x => x.IdPessoa == _id);

                    if (alunoEncontrado != null)
                    {
                        var indice = alunos.IndexOf(alunoEncontrado);

                        Console.WriteLine("Qual periodo de estudo atual do aluno: ");
                        var _periodoAtual = Console.ReadLine();

                        alunos[indice].Periodo = _periodoAtual.ToUpper();
                        Console.WriteLine($"Periodo do(a) aluno(a) {alunoEncontrado.Nome} atualizado com sucesso");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Código do aluno não encontrado não encontrado...");
                        break;
                    }
                }
                
            }
            Console.WriteLine();
        }
        public void AtualizarTurma(List<Aluno> alunos, List<Turma> turmas)
        {
            var _id = 0;
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
                    _id = int.Parse(_idAlunoStr);

                    var alunoEncontrado = alunos.FirstOrDefault(x => x.IdPessoa == _id);

                    if (alunoEncontrado != null)
                    {
                        var indice = alunos.IndexOf(alunoEncontrado);

                        Console.WriteLine("Qual a turma atual do aluno: ");
                        var _turmaAtual = int.Parse(Console.ReadLine());

                        var turmaEncontrada = turmas.FirstOrDefault(x => x.IdTurma == _turmaAtual);

                        if (turmaEncontrada != null)
                        {
                            alunos[indice].IdDaTurma = _turmaAtual;
                            Console.WriteLine($"Turma do(a) aluno(a) {alunoEncontrado.Nome} atualizado com sucesso");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Código da turma não encontrado não encontrado...");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Código do aluno não encontrado não encontrado...");
                        break;
                    }
                }
               
            }
            Console.WriteLine();
        }
        public override void Excluir(List<Turma> turmas)
        {
            var _id = 0;
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
                    _id = int.Parse(_idAlunoStr);

                    var alunoEncontrado = Alunos.FirstOrDefault(x => x.IdPessoa == _id);
                    if (alunoEncontrado != null)
                    {
                        Alunos.Remove(alunoEncontrado);
                        Console.WriteLine($"Aluno {alunoEncontrado.Nome} removido com sucesso!");
                        break;

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
        public override void Cadastrar()
        {
            throw new NotImplementedException();
        }
    }

}
