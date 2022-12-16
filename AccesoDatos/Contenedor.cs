using AccesoDatos.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Contenedor : Icontenedor
    {
        private readonly ApplicationDbContext _db;

        public Contenedor(ApplicationDbContext db)
        {
            _db = db;
            Categoria = new CategoriaRepositorio(_db);
            Producto = new ProductoRepositorio(_db);
        }

        public ICategoriaRepositorio Categoria { get; private set; }

 
          public IProductoRepositorio Producto { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
