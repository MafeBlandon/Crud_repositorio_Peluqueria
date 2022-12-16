using Microsoft.AspNetCore.Mvc.Rendering;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Data.Repository
{

    public interface IProductoRepositorio : Irepositorio<Producto>
    {
        //Primer metodonque nos optendra la lista de categoria
   
        //segundo merodo para actualizar
        void Update(Producto producto);
    }
}
