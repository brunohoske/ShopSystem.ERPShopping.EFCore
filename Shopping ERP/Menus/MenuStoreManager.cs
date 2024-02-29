using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopSystem.Data.DB;


namespace Shopping_ERP.Menus
{
    public class MenuStoreManager : Menu
    {
        public override void Execute(DAL<User> userDal, User user)
        {
            base.Execute(userDal, user);

            Console.WriteLine("Escolha a loja que deseja gerenciar: ");

            foreach (var loja in userDal.ListStores(user))
            {
                Console.WriteLine(loja.Name);
            }       

            string selectedStore = Console.ReadLine()!;

            if (selectedStore != null)
            {
                DAL<Store> storeDAL = new DAL<Store>(new ShopSystemContext());
                Store store = new Store();
                store = storeDAL.BuscarPor(s => s.Name == selectedStore);

                if(store != null)
                {
                    ; Dictionary<int, Menu> options = new Dictionary<int, Menu>();
                    options.Add(1, new MenuStoreManager());
                    options.Add(2, new MenuUserPanel());
                    options.Add(3, new MenuStoreRegister());

                    Console.Clear();
                    Console.WriteLine("Selecionado: " + store.Name);
                    Console.WriteLine("\nO que deseja Realizar?");
                    Console.WriteLine("1 - Atualizar informações da loja");
                    Console.WriteLine("2 - Visualizar o perfil da loja:");
                    Console.WriteLine("3 - Fechar loja (Apagar)");
                    Console.WriteLine("4 - Voltar");

                    int option = int.Parse(Console.ReadLine()!);
                    switch (option)
                    {
                        case 1:
                            AlterarCadastro(store);
                            break;
                        case 2: 
                            Console.Clear();
                            Console.WriteLine("Perfil: "+store.Name);
                            Console.WriteLine("\n\n"+store.ToString());
                            Console.WriteLine("\n\nPressione qualquer tecla para voltar ao Menu");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("Certeza que deseja apagar? Y/N");

                            char key = Console.ReadKey().KeyChar;

                            if (key == 'Y' || key == 'S')
                            {
                                storeDAL.Delete(store);
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Thread.Sleep(500);
                            }

                            break;
                        default: 
                            Thread.Sleep(500);
                            break;
                    }
                }
            }
        }

        public void AlterarCadastro(Store store)
        {
            Console.Clear();
            Console.WriteLine("Qual dado deseja atualizar?");
            Console.WriteLine("1 - Nome \n2 - Descrição\n3 - Site\n4 - Piso/Local");
            int option = int.Parse(Console.ReadLine()!);
            StoreDAL storeDAL = new StoreDAL(new ShopSystemContext());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Digite o novo nome");
                    string name = Console.ReadLine()!;
                    storeDAL.UpdateName(store, name);
                    Console.WriteLine("Dados atualizados com sucesso");
                    Thread.Sleep(400);
                    Console.WriteLine("Exibindo novo perfil de loja...");
                    Thread.Sleep(700);
                    Console.WriteLine(store.ToString());
                    Console.WriteLine("Digite qualquer tecla para sair");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Digite a nova descrição");
                    string description = Console.ReadLine()!;
                    storeDAL.UpdateDescription(store, description);
                    Console.WriteLine("Dados atualizados com sucesso");
                    Thread.Sleep(400);
                    Console.WriteLine("Exibindo novo perfil de loja...");
                    Thread.Sleep(700);
                    Console.WriteLine(store.ToString());
                    Console.WriteLine("Digite qualquer tecla para sair");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.WriteLine("Digite o novo CPF");
                    string url = Console.ReadLine()!;
                    storeDAL.UpdateUrl(store, url);
                    Console.WriteLine("Dados atualizados com sucesso");
                    Thread.Sleep(400);
                    Console.WriteLine("Exibindo novo perfil de loja...");
                    Thread.Sleep(700);
                    Console.WriteLine(store.ToString());
                    Console.WriteLine("Digite qualquer tecla para sair");
                    Console.ReadKey();
                    break;

                case 4:
                    Console.WriteLine("Digite o novo Local/Piso");
                    string local = Console.ReadLine()!;
                    storeDAL.UpdateLocation(store, local);
                    Console.WriteLine("Dados atualizados com sucesso");
                    Thread.Sleep(400);
                    Console.WriteLine("Exibindo novo perfil de loja...");
                    Thread.Sleep(700);
                    Console.WriteLine(store.ToString());
                    Console.WriteLine("Digite qualquer tecla para sair");
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("Voltando...");
                    Thread.Sleep(500);
                    break;
            }


        }

    }


}
