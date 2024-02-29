using ShopSystem.Data.DB;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_ERP.Menus
{
    internal class MenuStoreRegister : Menu
    {
        public override void Execute(DAL<User> userDAL, User user)
        {
            base.Execute(userDAL, user);

            Console.WriteLine("Digite o nome da loja:");
            string name = Console.ReadLine()!;
            Console.WriteLine("Digite a descrição da loja:");
            string description = Console.ReadLine()!;
            Console.WriteLine("Digite o piso em que a loja se encontrará.");
            string location = Console.ReadLine()!;
            Store store = new Store(name, description, location);

            DAL<Store> storeDal = new DAL<Store>(new ShopSystemContext());
           
            storeDal.AddStore(store,user.Id);
            Thread.Sleep(100);
            Console.WriteLine("Loja cadastrada com sucesso");

        }
    }
}
