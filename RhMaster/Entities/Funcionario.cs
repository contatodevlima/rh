using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RhMaster.Entities.Enum;

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

        // CONSTRUTORES
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

        // MÉTODOS
        public void InserirFuncionario()
        {
            Funcionario func = new Funcionario();
            Console.Write("Nome: ");
            func.Nome = Console.ReadLine();

            Console.Write("Data de nascimento: ex.(01/01/1999) ");
            func.DataNascimento = DateTime.Parse(Console.ReadLine());
            while (CalcIdade(func.DataNascimento) < 18)
            {
                Console.WriteLine(" :( Você está tentando cadastrar uma pessoa menor de idade");
                Console.Write("Data de nascimento: ex.(01/01/1999) ");
                func.DataNascimento = DateTime.Parse(Console.ReadLine());
            }

            Console.Write("Cpf: ");
            func.Cpf = Console.ReadLine();
            while (!(ValidaCpf(func.Cpf) && !(ExisteFuncionario(func.Cpf))))
            {
                Console.Write("CPF inválido ou já cadastrado, tente novamente: ");
                Console.WriteLine("Cpf: ");
                func.Cpf = Console.ReadLine();
            }

            Console.Write("Sexo: ex.(M/F)");
            func.Sexo = Char.Parse(Console.ReadLine());
            Console.Write("Nacionalidade: ");
            func.Nacionalidade = Console.ReadLine();
            Console.Write("Salário: ");
            func.Salario = double.Parse(Console.ReadLine());
            Console.Write("Cargo: ");
            func.Cargo = Console.ReadLine();
            func.Idade = CalcIdade(func.DataNascimento);
            
            func.Status = StatusFuncionario.Ativo;

            ListaFuncionario.Add(func);
            Console.WriteLine("Funcionário cadastrado com sucesso");
        }
        public bool ExisteFuncionario(string cpf)
        {
            return ListaFuncionario.Any(x => x.Cpf == cpf);
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
            Console.Write("Insira o Cpf para alterar o nome :");
            var cpf = Console.ReadLine();

            for (int i = 0; i < ListaFuncionario.Count; i++)
            {
                if (ListaFuncionario[i].Cpf == cpf)
                {
                    Console.Write("Insira o novo nome :");
                    var nome = Console.ReadLine();
                    ListaFuncionario[i].Nome = nome;
                    Console.WriteLine($"O nome foi alterado de{ListaFuncionario[i].Nome}, para {nome} com sucesso!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("CPF não cadastrado, tente novamente.");
                    Console.ReadKey();
                }
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
            Console.ReadKey();
        }
        
        public void ListarNovos()
        {
            foreach (var item in ListaFuncionario)
            {
                var novos = ListaFuncionario.Min(novos => novos.DataNascimento);
                Console.WriteLine(item.Nome);
                Console.ReadKey();
                break;
            }
        }

        public void ListarVelhos()
        {
            var velhos = ListaFuncionario.Max(velhos => velhos.DataNascimento);
            Console.WriteLine(velhos.Year);
            Console.ReadKey();
        }

        public void ListarPorIdade()
        {
            var listaIdade = ListaFuncionario.OrderBy(x => x.Idade);
            foreach (var item in listaIdade)
            {
                Console.WriteLine(item);
            }
        }
        public void SalarioPorSexo()
        {
            double SalM = ListaFuncionario.Where(y => y.Sexo == 'M' || y.Sexo == 'm').Sum(x => x.Salario);
            double SalF = ListaFuncionario.Where(y => y.Sexo == 'F' || y.Sexo == 'f').Sum(x => x.Salario);

            Console.WriteLine($"Salário total do sexo Feminino: {SalF}");
            Console.WriteLine($"Salário total do sexo Masculino: {SalM}");
        }

        #endregion



        public override string ToString()
        {
            return $"{Nome} - {DataNascimento.ToString("dd/MM/yyyy")} - {Cpf} - {Idade} - {Status}";
        }
    }

}
