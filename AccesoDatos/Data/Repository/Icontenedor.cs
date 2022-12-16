using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Data.Repository
{
    public interface Icontenedor : IDisposable // la pone disponible 
    {
        //
        ICategoriaRepositorio Categoria { get; } //get  
        IProductoRepositorio Producto { get; }

        void Save();//todo lo que hagamos se guarda 

    }
}
