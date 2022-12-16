using AccesoDatos.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class repositorio<T> : Irepositorio<T> where T : class
    {
        protected readonly DbContext context;
        internal DbSet<T> dbset;

        public repositorio(DbContext context)
        {
            context = context;
            this.dbset = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public T Get(int id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, OrderedParallelQuery<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbset;

            if (filter != null)

            {
                query = query.Where(filter);

            }



            if (includeProperties != null)
            {

                foreach (var property in includeProperties.Split(new char[] { ',' },
                        StringSplitOptions.RemoveEmptyEntries))

                {

                    query = query.Include(includeProperties);

                }
            }



            if (orderBy != null)
            {

                return orderBy(query).ToList();
            }


            return query.ToList();
        }

        public T GetFirsOrdefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbset;

            if (filter != null)

            {
                query = query.Where(filter);

            }

            if (includeProperties != null)
            {

                foreach (var property in includeProperties.Split(new char[] { ',' },
                        StringSplitOptions.RemoveEmptyEntries))   //remover entidad vacias

                {

                    query = query.Include(includeProperties);

                }
            }

            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T entitytoremove = dbset.Find(id);
            Remove(entitytoremove);
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }
    }
}
