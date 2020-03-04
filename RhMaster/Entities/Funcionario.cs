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
        public StatusFuncionario Status { get; set; }

        List<Funcionario> ListaFuncionario = new List<Funcionario>();

        // CONSTRUTORES
        public Funcionario()
        {
        }
        public Funcionario(string nome, DateTime dataNascimento, string cpf, char sexo, string nacionalidade, double salario, string cargo, StatusFuncionario status)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Sexo = sexo;
            Nacionalidade = nacionalidade;
            Salario = salario;
            Cargo = cargo;
            Status = status;
        }

        public void InserirFuncionario()
        {
            Funcionario func = new Funcionario();
            Console.Write("Nome: ");
            func.Nome = Console.ReadLine();
            Console.Write("Data de nascimento: ex.(01/01/1999) ");
            func.DataNascimento = DateTime.Parse(Console.ReadLine());

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
            func.Status = StatusFuncionario.Ativo;

            ListaFuncionario.Add(func);
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

        public override string ToString()
        {
            return $"{Nome} + {DataNascimento.ToString("dd/MM/yyyy")} + {Status}";
        }

        #region Buscas
        public void ListarFuncionarios()
        {
            foreach (var item in ListaFuncionario)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        public void Listarnovos()
        {
            foreach (var item in ListaFuncionario)
            {
                var novos = ListaFuncionario.Min(novos => novos.DataNascimento);
                Console.WriteLine(item.Nome);
                Console.ReadKey();
                break;
               
            }
                      
        }
        public void Listarvelhos()
        {
            var novos = ListaFuncionario.Max( novos => novos.DataNascimento);
            Console.WriteLine(novos.Year);
            Console.ReadKey();
        }
        #endregion
    }
}
