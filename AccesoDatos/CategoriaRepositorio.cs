using AccesoDatos.Data.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CategoriaRepositorio : repositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public IEnumerable<SelectListItem> GetlistaCateggoria()
        {
            return _db.Categoria.Select(i => new SelectListItem()

            {
                Text = i.Nombre,
                Value = i.id.ToString()
            });
        }

        public void Update(Categoria categoria)
        {
            // hacer esto cojn todos los datos de la tabla categoria
            var objDesdeDb = _db.Categoria.FirstOrDefault(s => s.id == categoria.id);
            objDesdeDb.Nombre = categoria.Nombre;
            objDesdeDb.Identificacion = categoria.Identificacion;
            objDesdeDb.Datos = categoria.Datos;
            _db.SaveChanges();
        }
    }
}
