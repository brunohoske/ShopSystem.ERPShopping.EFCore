using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Store> Stores { get; set; }

        public User() { }
        public User(string name, string email, string cpf, string password)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
            Password = password;
        }
        public override string ToString()
        {
            return $"Nome: {Name} \nCPF: {Cpf}\nEmail: {Email}";

        }


    }
}
