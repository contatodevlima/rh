using System;

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
                                    break;
                                case 2:

                                    break;
                                case 3:
                                       
                                    break;
                            }
                        }
                        while (subMenu != 0);
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

        #region Menu
        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine(" -  Digite a opção desejada");
            Console.WriteLine(" 1. Inserir funcionários ");
            Console.WriteLine(" 2. Alterar dados ");
            Console.WriteLine(" 3. Folha de Pagamento");
            Console.WriteLine(" 4. Ver salário por sexo ");
            Console.WriteLine(" 5. Buscar o funcionário mais velho da empresa ");
            Console.WriteLine(" 6. Buscar o funcionário mais novo da empresa");
            Console.WriteLine(" 7. Buscar todos os funcionários ordenados pela idade");
            Console.WriteLine(" 8. Buscar todos os funcionários pela nacionalidade");
            Console.WriteLine("____________________________");
            Console.WriteLine(" 0. Sair do sistema");
            return int.Parse(Console.ReadLine());
        }
        #endregion

        #region SubMenu
        public static int SubMenu()
        {
            Console.Clear();
            Console.WriteLine(" - Digite a opção de qual informação você deseja editar: ");
            Console.WriteLine(" 1. Alterar nome");
            Console.WriteLine(" 2. Alterar Data de nascimento");
            Console.WriteLine(" 3. Alterar Salário");
            Console.WriteLine(" 4. Alterar Status do funcionario");
            Console.WriteLine("____________________________");
            Console.WriteLine(" 0. Sair do sistema");
            return int.Parse(Console.ReadLine());

        }
        #endregion
    }
}