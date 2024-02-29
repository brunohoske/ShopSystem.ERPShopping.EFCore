using ShopSystem.Data.DB;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_ERP.Menus
{
    public class  Menu
    {

        public virtual void Execute(DAL<User> userDal, User user)
        {
            Console.Clear();
        }

        public static User Register()
        {
            Console.WriteLine("Cadastro de usuario");
            Console.WriteLine("Digite seu nome");
            string name = Console.ReadLine()!;
            Console.WriteLine("Digite seu email");
            string email = Console.ReadLine()!;
            Console.WriteLine("Digite seu CPF");
            string cpf = Console.ReadLine()!;
            Console.WriteLine("Digite sua senha");
            string senha = Console.ReadLine()!;
            Console.WriteLine("Confirme a senha");
            string confirmSenha = Console.ReadLine()!;

            if (senha != confirmSenha)
            {
                return Register();

            }
            else
            {
                User user = new User(name, email, cpf, senha);
                DAL<User> userDAL = new DAL<User>(new ShopSystemContext());
                userDAL.Add(user);

                Console.WriteLine("Cadastro Realizado com sucesso");


                Thread.Sleep(2000);
                return user;
            }
        }

        public static User SolicitarLogin()
        {
            Console.Clear();
            Console.WriteLine("Faça seu login: (digite -1 para realizar um cadastro) ");
            Console.WriteLine("Digite seu email");

            DAL<User> userDal = new DAL<User>(new ShopSystemContext());
            User user;

            string email = Console.ReadLine();
            user = userDal.BuscarPor(a => a.Email == email);

            if(user == null || email == "-1" )
            { 
                return Register();
            }
            else
            {
                Console.WriteLine("Digite sua senha");

                string password = Console.ReadLine();
                if (user.Password == password)
                {
                    return user;
                }
                else
                {
                    Console.WriteLine("Senha incorreta");
                    Thread.Sleep(2000);
                    return null;
                }
            }
            




        }


    }
}
