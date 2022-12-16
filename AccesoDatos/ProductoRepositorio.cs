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
     public class ProductoRepositorio : repositorio<Producto>, IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public ProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Producto producto)
        {
            // hacer esto cojn todos los datos de la tabla categoria
            var objDesdeDb = _db.Producto.FirstOrDefault(s => s.Id == producto.Id);
            objDesdeDb.Nombre = producto.Nombre;
            objDesdeDb.Valor = producto.Valor;
            objDesdeDb.Imagen = producto.Imagen;
            objDesdeDb.CategoriaId = producto.CategoriaId;
            _db.SaveChanges();
        }
    }
}
