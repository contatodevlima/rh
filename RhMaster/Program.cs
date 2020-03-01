using System;

namespace RhMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            int escolha = 10;
            Funcionario f = new Funcionario();
            
            do
            {
                escolha = Menu();

                if (escolha == 1)
                {
                    // metodo validarcpf())

                }
                else if (escolha == 2)
                {
                    // método alterardados() ) 
                }

                else if (escolha == 3)
                {
                    //étodo folha de pagamento())
                }

                if (escolha == 4)
                {
                    // metodo Ver salário por sexo())

                }
                else if (escolha == 5)
                {
                    // Buscar o funcionário mais velho da empresa() ) 
                }
                else if (escolha == 6)
                {
                    // Buscar o funcionário mais novo da empresa() ) 
                }
                else if (escolha == 7)
                {
                    // Buscar todos os funcionários ordenados pela idade() ) 
                }
                else if (escolha == 8)
                {
                    // Buscar todos os funcionários pela nacionalidade() ) 
                }


            } while (escolha != 0);
            
        }
        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine(" 1. Gerenciar funcionários ");    //(cai no metodo validarcpf())
            Console.WriteLine(" 2. Alterar dados ");            //(cai no método alterardados() )
            Console.WriteLine(" 3. Folha de Pagamento");        //(cai no método folha de pagamento())                           
            Console.WriteLine(" 4. Ver salário por sexo ");
            Console.WriteLine(" 5. Buscar o funcionário mais velho da empresa ");
            Console.WriteLine(" 6. Buscar o funcionário mais novo da empresa");
            Console.WriteLine(" 7. Buscar todos os funcionários ordenados pela idade");
            Console.WriteLine(" 8. Buscar todos os funcionários pela nacionalidade");
            Console.WriteLine("____________________________");
            Console.WriteLine(" 0. Sair do sistema");
            return int.Parse(Console.ReadLine());
        }

    }
}


