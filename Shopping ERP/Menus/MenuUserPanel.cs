using ShopSystem.Data.DB;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_ERP.Menus
{
    public class MenuUserPanel : Menu
    {
        public override void Execute(DAL<User> userDal, User user)
        {
            base.Execute(userDal, user);

            Console.WriteLine("Bos vindas,"+user.Name);
            Console.WriteLine("Escolha o que deseja fazer:");

            Console.WriteLine("1 - Procurar lojas");
            Console.WriteLine("2 - Alterar dados cadastrais");
            Console.WriteLine("3 - Ver perfil");

            int option = int.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    Console.WriteLine();
                    while(option == 1)
                    {
                        BuscarLojas();
                        Console.WriteLine("Digite 1 para Pesquisar novamente. -1 para sair");
                        option = int.Parse(Console.ReadLine()!) ;
                    }
                   
                    break;
                case 2:
                    Console.WriteLine();
                    AlterarCadastro(user);
                    break;
                case 3:
                    Console.WriteLine("Visualizando o perfil de: "+ user.Name);
                    Console.WriteLine(user.ToString());
                    Console.WriteLine("Digite uma tecla para continuar");
                    Console.ReadKey();
                    break;
            }

        }
        public void BuscarLojas()
        {
            Console.Clear();
            Console.WriteLine("Como deseja procurar as lojas?");
            Console.WriteLine("1 - Nome \n2 - Descrição\n3 - Site\n4 - Piso\n5 - CNPJ");
            int option = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Digite sua busca: ");
            string busca = Console.ReadLine()!;
            DAL<Store> store = new DAL<Store>(new ShopSystemContext());
            Console.WriteLine("Resultados:");
            switch (option)
            {
                case 1:
                    var list = store.ListarPor(x => x.Name.ToLower().Contains(busca.ToLower()));
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                        Console.WriteLine("----------------------");
                    }
                    break;
                case 2:
                    var list1 = store.ListarPor(x => x.Description.ToLower().Contains(busca.ToLower()));
                    foreach (var item in list1)
                    {
                        Console.WriteLine(item);
                        Console.WriteLine("----------------------");
                    }
                    break;
                case 3:
                    var list2 = store.ListarPor(x => x.Url.ToLower().Contains(busca.ToLower()));
                    foreach (var item in list2)
                    {
                        Console.WriteLine(item);
                        Console.WriteLine("----------------------");
                    }
                    break;
                case 4:
                    var list3 = store.ListarPor(x => x.Location.ToLower() == busca.ToLower());
                    foreach (var item in list3)
                    {
                        Console.WriteLine(item);
                        Console.WriteLine("----------------------");
                    }
                   
                    break;
                case 5:
                    
                    break;
                default:
                    Console.WriteLine("Voltando...");
                    break;

            }


        }

        public void AlterarCadastro(User user)
        {
            Console.Clear();
            Console.WriteLine("Qual dado deseja atualizar?");
            Console.WriteLine("1 - Nome \n2 - Email\n3 - CPF\n4 - Senha");
            int option = int.Parse(Console.ReadLine()!);
            UserDAL userDAL = new UserDAL(new ShopSystemContext());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Digite o novo nome");
                    string name = Console.ReadLine()!;
                    userDAL.UpdateName(user, name);
                    Console.WriteLine("Dados atualizados com sucesso");
                    Thread.Sleep(400);
                    Console.WriteLine("Exibindo novo perfil...");
                    Thread.Sleep(700);
                    Console.WriteLine(user.ToString()); 
                    Console.WriteLine("Digite qualquer tecla para sair");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Digite o novo email");
                    string email = Console.ReadLine()!;
                    userDAL.UpdateEmail(user, email);
                    Console.WriteLine("Dados atualizados com sucesso");
                    Thread.Sleep(400);
                    Console.WriteLine("Exibindo novo perfil...");
                    Thread.Sleep(700);
                    Console.WriteLine(user.ToString());
                    Console.WriteLine("Digite qualquer tecla para sair");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.WriteLine("Digite o novo CPF");
                    string cpf = Console.ReadLine()!;
                    userDAL.UpdateCPF(user, cpf);
                    Console.WriteLine("Dados atualizados com sucesso");
                    Thread.Sleep(400);
                    Console.WriteLine("Exibindo novo perfil...");
                    Thread.Sleep(700);
                    Console.WriteLine(user.ToString());
                    Console.WriteLine("Digite qualquer tecla para sair");
                    Console.ReadKey();
                    break;

                case 4:
                    Console.WriteLine("Digite sua senha");
                    string senha = Console.ReadLine()!;

                    if(senha == user.Password)
                    {
                        Console.WriteLine("...");
                        Console.WriteLine("Digite sua nova senha");
                        string newSenha = Console.ReadLine()!;
                        Console.WriteLine("Confirme sua senha");
                        string confirm = Console.ReadLine()!;
                        if(confirm == newSenha)
                        {
                            userDAL.UpdatePass(user, newSenha);
                            Console.WriteLine("Dados atualizados com sucesso");
                            Thread.Sleep(400);
                            Console.WriteLine("Exibindo novo perfil...");
                            Thread.Sleep(700);
                            Console.WriteLine(user.ToString());
                            Console.WriteLine("Digite qualquer tecla para sair");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Senha incorreta");
                        Console.ReadKey();
                    }
                    break;

                default:
                    Console.WriteLine("Voltando...");
                    Thread.Sleep(500);
                    break;
            }

            
        }
    }

}


   
