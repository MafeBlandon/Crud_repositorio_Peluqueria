using Microsoft.AspNetCore.Mvc.Rendering;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Data.Repository
{
    public interface ICategoriaRepositorio : Irepositorio<Categoria>
    {
        //Primer metodonque nos optendra la lista de categoria
        IEnumerable<SelectListItem> GetlistaCateggoria();
        //segundo merodo para actualizar
        void Update(Categoria categoria);
    }
}
