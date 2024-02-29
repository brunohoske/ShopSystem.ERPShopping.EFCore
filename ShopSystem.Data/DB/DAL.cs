using Microsoft.EntityFrameworkCore;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Data.DB
{
    public class DAL<T> where T : class
    {

        public readonly ShopSystemContext context;

        public DAL(ShopSystemContext context)
        {
            this.context = context;
        }
        public IEnumerable<T> List()
        {
            return context.Set<T>().ToList();
        }

        public List<Store> ListStores(User user)
        {
            int idUser = user.Id;
            var lojasDoUsuario = context.Set<Store>()
           .Where(store => store.IdUser == idUser)
           .AsNoTracking() //Quando é realizado uma alteração no banco de dados o contexto mantem o ponto inicial para analisar suas mudanças, então quando
           .ToList();      //fazemos esse metodo buscar pelo context, automaticamente ele usa as trackings, que é o que citei acima, então desativamos isso
                           //para buscar diretamente no valor real dela


            return lojasDoUsuario;
        }


        public void Add(T obj) 
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }


        public void AddStore(Store store, int idUsuario)
        {
            var user = context.Set<User>().Any(user => user.Id == idUsuario);

            store.IdUser = idUsuario;

            context.Set<Store>().Add(store);

            context.SaveChanges();
        }
        public void Delete(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }
        public T? BuscarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().FirstOrDefault(condicao);
        }
        public IEnumerable<T> ListarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().Where(condicao);
        }
    }
}
