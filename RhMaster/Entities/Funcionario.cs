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
        public Funcionario() { 
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

        public  void InserirFuncionario()
        {
            Funcionario func = new Funcionario();
            Console.WriteLine("Nome: ");
            func.Nome = Console.ReadLine();
            Console.WriteLine("Data de nascimento: ex.(01/01/1999) ");
            func.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Cpf: ");
            func.Cpf = Console.ReadLine();
            while(!(ValidaCpf(func.Cpf) && !(ExisteFuncionario(func.Cpf))))
            {
                Console.WriteLine("CPF inválido ou já cadastrado na base");
                Console.WriteLine("Cpf: ");
                func.Cpf = Console.ReadLine();
            }
            
            Console.WriteLine("Sexo: ex.(M/F)");
            func.Sexo = Char.Parse(Console.ReadLine());
            Console.WriteLine("Nacionalidade: ");
            func.Nacionalidade = Console.ReadLine();
            Console.WriteLine("Salário: ");
            func.Salario = double.Parse(Console.ReadLine());
            Console.WriteLine("Cargo: ");
            func.Cargo = Console.ReadLine();
            func.Status = StatusFuncionario.Ativo;

            ListaFuncionario.Add(func);
        }

        public void ListarFuncionarios()
        {
            foreach (var item in ListaFuncionario)
            {
                Console.WriteLine(item);
            }
        }
        public bool ExisteFuncionario(string cpf)
        {
            return ListaFuncionario.Any(x => x.Cpf == cpf);
        }

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
        
        public override string ToString()
        {
            return $"{Nome} + {DataNascimento.ToString("dd/MM/yyyy")} + {Status}";
        }
    }
}
