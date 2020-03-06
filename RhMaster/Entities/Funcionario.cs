using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RhMaster.Entities.Enum;
using RhMaster.Entities;

namespace RhMaster
{
    class Funcionario
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Cpf { get; set; }
        public char Sexo { get; set; }
        public string Nacionalidade { get; set; }
        public double Salario { get; set; }
        public string Cargo { get; set; }
        public int Idade { get; set; }
        public StatusFuncionario Status { get; set; }

        List<Funcionario> ListaFuncionario = new List<Funcionario>();

        public Funcionario()
        {
        }
        public Funcionario(string nome, DateTime dataNascimento, string cpf, char sexo, string nacionalidade, double salario, string cargo, int idade, StatusFuncionario status)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Sexo = sexo;
            Nacionalidade = nacionalidade;
            Salario = salario;
            Cargo = cargo;
            Idade = idade;
            Status = status;
        }

        public void InserirFuncionario()
        {
            Funcionario func = new Funcionario();
            Console.Write("Nome: ");
            func.Nome = Console.ReadLine();
            Console.Write("Data de nascimento: ex.(01/01/1999) ");
            func.DataNascimento = DateTime.Parse(Console.ReadLine());
            while (CalcIdade(func.DataNascimento) < 18)
            {
                Console.WriteLine("Não é possível cadastrar um funcionário menor de idade");
                Console.Write("Data de nascimento: ex.(01/01/1999) ");
                func.DataNascimento = DateTime.Parse(Console.ReadLine());
            }
            func.Idade = CalcIdade(func.DataNascimento);
            
            Console.Write("Cpf: ");
            func.Cpf = Console.ReadLine();
            while (!(ValidaCpf(func.Cpf) && !(ExisteFuncionario(func.Cpf))))
            {
                Console.Write("CPF inválido ou já cadastrado, tente novamente: ");
                Console.WriteLine("Cpf: ");
                func.Cpf = Console.ReadLine();
            }

            Console.Write("Sexo: ex.(M/F)");
            char sex = Char.Parse(Console.ReadLine());
            while (!(sex != 'M' || sex != 'm' || sex != 'F' || sex != 'f'))
            {
                Console.WriteLine("Incorreto!");
                Console.Write("Sexo: ex.(M/F)");
                sex = Char.Parse(Console.ReadLine());
            }
            func.Sexo = sex;
            Console.Write("Nacionalidade: ");
            func.Nacionalidade = Console.ReadLine();
            Console.Write("Salário: ");
            func.Salario = double.Parse(Console.ReadLine());
            Console.Write("Cargo: ");
            func.Cargo = Console.ReadLine();
            func.Status = StatusFuncionario.Ativo;

            ListaFuncionario.Add(func);
            Console.WriteLine();
            Console.WriteLine("Inserido com sucesso!");
            Console.ReadLine();
        }
        public bool ExisteFuncionario(string cpf)
        {
            return ListaFuncionario.Any(x => x.Cpf == cpf);
        }
        public int ExisteAlgumFuncionario()
        {
            return ListaFuncionario.Count();
        }
        public void VerFolhaPagamento()
        {
            Contabilidade c = new Contabilidade();
            c.CalculaImposto(ListaFuncionario);
        }
        public StatusFuncionario FuncAtivo(string cpf)
        {
            return ListaFuncionario.Where(x => x.Cpf == cpf).FirstOrDefault().Status;
        }

        #region Validando Cpf
        public bool ValidaCpf(string cpf)

        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf, digito;
            int soma, resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)

                return false;

            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
        #endregion

        #region Calculo Idade
        public int CalcIdade(DateTime data)
        {
            int idade = DateTime.Now.Year - data.Year;
            if (DateTime.Now.DayOfYear < data.DayOfYear)
                return idade;
            else
            return idade - 1;
        }
        #endregion

        #region Métodos de alteração de dados
        public void AlterarNome()
        {
            Console.Write("Insira o cpf de quem deseja alterar o nome: ");
            string cpf = Console.ReadLine();
            var nomeNovo = ListaFuncionario.FirstOrDefault(x => x.Cpf == cpf);

            if (nomeNovo != null)
            {
                Console.WriteLine("Insira o novo nome: ");
                nomeNovo.Nome = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Funcionário não existe na base!");
                Console.ReadLine();
            }
           
        }

        public void alterarSalario()
        {
            Console.Write("Insira o cpf de quem deseja alterar o salário: ");
            string cpf = Console.ReadLine();
            var nomeNovo = ListaFuncionario.FirstOrDefault(x => x.Cpf == cpf);

            if (nomeNovo != null)
            {
                Console.WriteLine("Insira o novo cargo: ");
                nomeNovo.Cargo = Console.ReadLine();
                Console.WriteLine("Insira o novo salário");
                nomeNovo.Salario = double.Parse(Console.ReadLine());
                Console.WriteLine("Alterado com sucesso!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Funcionário não existe na base!");
                Console.ReadLine();
            }
        }

        public void alterarStatus()
        {
            Console.Write("Insira o cpf de quem deseja alterar o status: ");
            string cpf = Console.ReadLine();
            var nomeNovo = ListaFuncionario.FirstOrDefault(x => x.Cpf == cpf);

            if (nomeNovo != null)
            {
                Console.WriteLine("Digite 1 - Desligar 2 - Ativar");
                int op = int.Parse(Console.ReadLine());
                if (op == 1)
                    nomeNovo.Status = StatusFuncionario.Desligado;
                else if(op == 2)
                    nomeNovo.Status = StatusFuncionario.Ativo;
                else
                    Console.WriteLine("Opção inválida!");

                Console.WriteLine("Alterado com sucesso!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Funcionário não existe na base!");
                Console.ReadLine();
            }
        }

        #endregion

        #region Buscas
        public void ListarFuncionarios()
        {
            foreach (var item in ListaFuncionario)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        
        public void ListarNovo()
        {
            var novos = ListaFuncionario.OrderBy(x => x.DataNascimento).LastOrDefault();
            Console.WriteLine($"O funcionário(a) mais novo é o(a): {novos.Nome} com {novos.Idade} anos");
            Console.ReadLine();
        }

        public void ListarVelho()
        {
            var velhos = ListaFuncionario.OrderBy(x => x.DataNascimento).FirstOrDefault();
            Console.WriteLine("");
            Console.WriteLine($"O funcionário(a) mais velho da empresa é o(a): {velhos.Nome} com {velhos.Idade} anos");
            Console.ReadLine();
        }

        public void ListarPorIdade()
        {
            var listaIdade = ListaFuncionario.OrderBy(x => x.Idade);
            foreach (var item in listaIdade)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        public void SalarioPorSexo()
        {
            double SalM = ListaFuncionario.Where(y => y.Sexo == 'M' || y.Sexo == 'm').Sum(x => x.Salario);
            double SalF = ListaFuncionario.Where(y => y.Sexo == 'F' || y.Sexo == 'f').Sum(x => x.Salario);

            Console.WriteLine("        Salário Total por Sexo         ");
            Console.WriteLine($"Salário total do sexo Feminino: {SalF}");
            Console.WriteLine($"Salário total do sexo Feminino: {SalM}");
            Console.ReadLine();
        }

        #endregion



        public override string ToString()
        {
            return $"{Nome} - {DataNascimento.ToString("dd/MM/yyyy")} - {Cpf} - {Idade} anos - {Salario} - {Status}";
        }
    }

}
