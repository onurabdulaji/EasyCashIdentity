using EasyCashIdentity.DataAccessLayer.Abstract;
using EasyCashIdentity.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentity.DataAccessLayer.Repositories
{
    public class GenericRepository <T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            //throw new NotImplementedException();
            using var context = new Context();
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }

        public T GetByID(int id)
        {
            //throw new NotImplementedException();
            using var context = new Context();
            return context.Set<T>().Find(id);
            // It can return Null
        }

        public List<T> GetList()
        {
            //throw new NotImplementedException();
            using var context = new Context();
            return context.Set<T>().ToList();   
        }

        public void Insert(T t)
        {
            //throw new NotImplementedException();
            using var context = new Context();
            context.Set<T>().Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            //throw new NotImplementedException();
            using var context = new Context();
            context.Set<T>().Update(t);
            context.SaveChanges();
        }
    }
}
