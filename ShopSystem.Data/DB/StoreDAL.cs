using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Data.DB
{
    public class StoreDAL : DAL<Store>
    {
        public StoreDAL(ShopSystemContext context) : base(context)
        {
        }

        public void UpdateName(Store store, string newName)
        {
            var entityUpdate = context.Set<Store>().FirstOrDefault(s => s.Id == store.Id);

            if (entityUpdate != null)
            {
                store.Name = newName;
                entityUpdate.Name = newName;
                context.Entry(entityUpdate).Property("Name").IsModified = true;

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Usuario não encontrado.");
            }
        }

        public void UpdateDescription(Store store, string newDesc)
        {
            var entityUpdate = context.Set<Store>().FirstOrDefault(s => s.Id == store.Id);

            if (entityUpdate != null)
            {
                store.Description = newDesc;
                entityUpdate.Description = newDesc;
                context.Entry(entityUpdate).Property("Description").IsModified = true;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Usuario não encontrado.");
            }
        }

        public void UpdateUrl(Store store, string newUrl)
        {
            var entityUpdate = context.Set<Store>().FirstOrDefault(s => s.Id == store.Id);

            if (entityUpdate != null)
            {
                store.Url = newUrl;
                entityUpdate.Url = newUrl;
                context.Entry(entityUpdate).Property("Url").IsModified = true;

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Usuario não encontrado.");
            }
        }

        public void UpdateLocation(Store store, string newLocal)
        {
            var entityUpdate = context.Set<Store>().FirstOrDefault(s => s.Id == store.Id);
            if (entityUpdate != null)
            {
                store.Location = newLocal;
                entityUpdate.Location = newLocal;
                context.Entry(entityUpdate).Property("Location").IsModified = true;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Usuario não encontrado.");
            }
        }
    }
}
