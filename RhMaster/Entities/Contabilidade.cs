using System;
using System.Collections.Generic;
using System.Text;

namespace RhMaster.Entities
{
    class Contabilidade
    {
        public double Imposto = 1.55;
        public double soma = 0;
        public double somaSemImposto = 0;

        public void CalculaImposto(List<Funcionario> l)
        {
            foreach (var item in l)
            {
                Console.WriteLine($"{item.Nome} - Salário: {item.Salario} reais - Salário com impostos {(item.Salario * Imposto).ToString("f2")} reais");
                somaSemImposto += item.Salario;
                soma += item.Salario * Imposto;
            }
            Console.WriteLine($"Total sem imposto {somaSemImposto}");
            Console.WriteLine($"Total com imposto {soma}");
            Console.ReadLine();
        }
    }
}
