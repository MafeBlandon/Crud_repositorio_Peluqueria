using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Data.Repository
{
    public interface Irepositorio<T> where T : class
    {
        T Get(int id);

        IEnumerable<T> GetAll( // metodo que retorna los datos 
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, OrderedParallelQuery<T>> orderBy = null,
                string includeProperties = null
            );

        T GetFirsOrdefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null);

        void Add(T entity);

        void Remove(int id);
        void Remove(T entity);

    }    
}
