using Microsoft.Extensions.Options;
using Shopping_ERP.Menus;
using ShopSystem.Data.DB;
using ShopSystem.Models;
using System;


//User user = new User("bruno", "brunohoske@gmail.com", "123") { Stores = new List<Store>() };

var dalUser = new DAL<User>(new ShopSystemContext());



void ExibirLogo()
{
    Console.WriteLine(@"


▒█▀▀▀█ ▒█░░▒█ ▒█▀▀▀█ ▀▀█▀▀ ▒█▀▀▀ ▒█▀▄▀█ ▒█▀▀▀█ ▒█░▒█ ▒█▀▀▀█ ▒█▀▀█ 
░▀▀▀▄▄ ▒█▄▄▄█ ░▀▀▀▄▄ ░▒█░░ ▒█▀▀▀ ▒█▒█▒█ ░▀▀▀▄▄ ▒█▀▀█ ▒█░░▒█ ▒█▄▄█ 
▒█▄▄▄█ ░░▒█░░ ▒█▄▄▄█ ░▒█░░ ▒█▄▄▄ ▒█░░▒█ ▒█▄▄▄█ ▒█░▒█ ▒█▄▄▄█ ▒█░░░
");
}
void ExibirMenuPrincipal(User user)
{
    Console.Clear();
    Console.WriteLine("Boas Vindas ao");
    ExibirLogo();

    Console.WriteLine("\nDigite 1 para entrar no painel de gerenciamento de loja");
    Console.WriteLine("Digite 2 para entrar no painel do Cliente");
    Console.WriteLine("Digite 3 para registar uma loja");
    Console.WriteLine("Digite -1 para sair");


    Dictionary<int, Menu> options = new Dictionary<int, Menu>();
    options.Add(1, new MenuStoreManager());
    options.Add(2, new MenuUserPanel());
    options.Add(3, new MenuStoreRegister());


    int option = int.Parse(Console.ReadLine());

    if (options.ContainsKey(option))
    {

        Menu ExibirMenu = options[option];

        ExibirMenu.Execute(dalUser, user);

        if (option > 0) { ExibirMenuPrincipal(user); }
        else
        {
            Console.WriteLine("Tchau");
        }
        
      
    }
}

User user = Menu.SolicitarLogin();
if (user != null)
{
    ExibirMenuPrincipal(user);
}

