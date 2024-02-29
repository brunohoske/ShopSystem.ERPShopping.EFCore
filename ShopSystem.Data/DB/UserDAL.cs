using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Data.DB
{
    public class UserDAL : DAL<UserDAL>
    {
        public UserDAL(ShopSystemContext context) : base(context){}

        public void UpdatePass(User user, string newPass)
        {
            var entityUpdate = context.Set<User>().FirstOrDefault(user => user.Id == user.Id);

            if (entityUpdate != null)
            {
                user.Password = newPass;
                entityUpdate.Password = newPass;
                context.Entry(entityUpdate).Property("Password").IsModified = true;

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Usuario não encontrado.");
            }
        }
        public void UpdateName(User user, string newName)
        {
            var entityUpdate = context.Set<User>().FirstOrDefault(user => user.Id == user.Id);

            if (entityUpdate != null)
            {
                user.Name = newName;
                entityUpdate.Name = newName;
                context.Entry(entityUpdate).Property("Name").IsModified = true;

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Usuario não encontrado.");
            }
        }
        public void UpdateEmail(User user, string newEmail)
        {
            var entityUpdate = context.Set<User>().FirstOrDefault(user => user.Id == user.Id);


            if (entityUpdate != null)
            {
                user.Email = newEmail;
                entityUpdate.Email = newEmail;
                context.Entry(entityUpdate).Property("Email").IsModified = true;

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Usuario não encontrado.");
            }
        }
        public void UpdateCPF(User user, string newCpf)
        {
            var entityUpdate = context.Set<User>().FirstOrDefault(user => user.Id == user.Id);


            if (entityUpdate != null)
            {
                user.Cpf = newCpf;
                entityUpdate.Cpf = newCpf;
                context.Entry(entityUpdate).Property("Cpf").IsModified = true;

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Usuario não encontrado.");
            }
        }

    }
}
