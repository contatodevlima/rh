using System;

namespace RhMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            int escolha;
            Funcionario f = new Funcionario();

            escolha = Menu();
            do
            {
                switch (escolha)
                {
                    case 1:
                        f.InserirFuncionario();
                        break;
                    case 2:
                        // método alterardados() )
                        break;
                    case 3:
                        // método folha de pagamento())   
                        break;
                    case 4:
                        // Ver salário por sexo
                        break;
                    case 5:
                        // Buscar o funcionário mais velho da empresa
                        break;
                    case 6:
                        // Buscar o funcionário mais novo da empresa
                        break;
                    case 7:
                        // Buscar todos os funcionários ordenados pela idade
                        break;
                    case 8:
                        // Buscar todos os funcionários pela nacionalidade
                        break;
                }
            }
            while (escolha != 0);
        }        
        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine(" 1. Inserir funcionários ");    //(cai no metodo validarcpf())
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