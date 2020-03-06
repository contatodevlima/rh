using System;
using System.Globalization;

namespace RhMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            int escolha, subMenu;
            Funcionario f = new Funcionario();

            do
            {
                if (f.ExisteAlgumFuncionario() == 0)
                    escolha = MenuInicial();
                else
                    escolha = Menu();

                switch (escolha)
                {
                    case 1:
                        f.InserirFuncionario();
                        break;

                    case 2:
                        do
                        {
                            subMenu = SubMenu();
                            switch (subMenu)
                            {
                                case 1:
                                    f.AlterarNome();
                                    break;
                                case 2:
                                    f.alterarSalario();
                                    break;
                                case 3:
                                    f.alterarStatus();
                                    break;
                            }
                        }
                        while (subMenu != 0);
                        break;

                    case 3:
                        f.VerFolhaPagamento();
                        break;

                    case 4:
                        f.SalarioPorSexo();
                        break;

                    case 5:
                        f.ListarVelho();
                        break;

                    case 6:
                        f.ListarNovo();
                        break;

                    case 7:
                        f.ListarPorIdade();
                        break;

                    case 8:
                        f.ListarFuncionarios();
                        break;
                }
            }
            while (escolha != 0);
        }

        #region MenuInicial
        public static int MenuInicial()
        {
            Console.Clear();
            Console.WriteLine("____________________RH MASTER____________________________");
            Console.WriteLine(" 1. Inserir funcionários                                 ");          
            Console.WriteLine(" 0. Sair do sistema                                      ");
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine(" -  Digite a opção desejada: ");
            return int.Parse(Console.ReadLine());
        }
        #endregion

        #region Menu
        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine("____________________RH MASTER____________________________");
            Console.WriteLine(" 1. Inserir funcionários                                 ");
            Console.WriteLine(" 2. Alterar dados                                        ");
            Console.WriteLine(" 3. Folha de Pagamento                                   ");
            Console.WriteLine(" 4. Ver total de salário por sexo                        ");
            Console.WriteLine(" 5. Buscar o funcionário mais velho da empresa           ");
            Console.WriteLine(" 6. Buscar o funcionário mais novo da empresa            ");
            Console.WriteLine(" 7. Buscar todos os funcionários ordenados pela idade    ");
            Console.WriteLine(" 8. Buscar todos os funcionários pela nacionalidade");
            Console.WriteLine(" 0. Sair do sistema                                      ");
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine(" -  Digite a opção desejada: ");
            return int.Parse(Console.ReadLine());
        }
        #endregion

        #region SubMenu
        public static int SubMenu()
        {
            Console.Clear();
            Console.WriteLine("__________________RH MASTER____________");
            Console.WriteLine(" 1. Alterar nome                       ");
            Console.WriteLine(" 2. Alterar Salário                    ");
            Console.WriteLine(" 3. Alterar Status do funcionário      ");
            Console.WriteLine(" 0. Voltar ao menu principal           ");
            Console.WriteLine("_______________________________________");
            Console.WriteLine(" Digite a opção que deseja alterar: ");
           
            return int.Parse(Console.ReadLine());
        }
        #endregion
    }
}