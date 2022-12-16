using AccesoDatos.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Modelos;

namespace completoOne.Areas.Admin.Controllers
{
   
    [Area("Admin")]
    //con todas las tablas 
    public class ProductoController : Controller
    {
        private readonly Icontenedor _contenedor;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductoController(Icontenedor contenedor, IWebHostEnvironment hostEnvironment)
        {
            _contenedor = contenedor;
           _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
    


        public IActionResult Create()
        {
           ArticuloVm articuloVm = new ArticuloVm()
           {
                Producto = new Modelos.Producto(),
                ListaCateggorias = _contenedor.Categoria.GetlistaCateggoria()
            }; 
            return View(articuloVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ArticuloVm articuloVm)
        {
            if (ModelState != null)
            {
                //nos envia los datoa a la ruta principL EN ESTE CASO EL WWROOT
                string rutaPrincipal = _hostEnvironment.WebRootPath;
                //CREAMOS UNA VARIABLE PARA ACCEDER A LA FILA 
                var archivos = HttpContext.Request.Form.Files;
                if(articuloVm.Producto.Id == 0)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\articulos");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);

                    }
                    articuloVm.Producto.Imagen = @"imagenes\articulos" + nombreArchivo + extension;
                    

                    _contenedor.Producto.Add(articuloVm.Producto);
                    _contenedor.Save();

                    return RedirectToAction(nameof(Index));

                }

               
            }
                  return View();
        }





        #region LLAMADAS A LAS API
        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new { data = _contenedor.Producto.GetAll(includeProperties:"Categoria") });
        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedor.Producto.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando Producto" });

            }
            _contenedor.Producto.Remove(objFromDb);
            _contenedor.Save();
            return Json(new { success = true, message = "Producto borrada correctamente " });

        }
        #endregion
        /*
     [HttpGet]
     public IActionResult Edit(int id)
     {
         Producto producto = new Producto();
         producto = _contenedor.Producto.Get(id);
         if (producto == null)
         {
             return NotFound();
         }
         return View(producto);
     }

     [HttpPost]
     [ValidateAntiForgeryToken]
     public IActionResult Edit(Producto producto)
     {
         if (ModelState.IsValid)
         {
             _contenedor.Producto.Update(producto);
             _contenedor.Save();
             return RedirectToAction(nameof(Index));

         }
         return View(producto);
     }*/

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ArticuloVm articuloVm = new ArticuloVm()
            {
                Producto = new Producto(),
                ListaCateggorias = _contenedor.Categoria.GetlistaCateggoria()
            };

            if (id != null)
            {
                articuloVm.Producto = _contenedor.Producto.Get(id.GetValueOrDefault());
            }
            return View(articuloVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ArticuloVm articuloVm)
        {
            if (ModelState != null)
            {
                //nos envia los datoa a la ruta principL EN ESTE CASO EL WWROOT
                string rutaPrincipal = _hostEnvironment.WebRootPath;
                //CREAMOS UNA VARIABLE PARA ACCEDER A LA FILA 
                var archivos = HttpContext.Request.Form.Files;

                var articuloDesdeDb = _contenedor.Producto.Get(articuloVm.Producto.Id);
                if (archivos.Count() > 0)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\articulos");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);

                    var rutaImagen = Path.Combine(rutaPrincipal, articuloDesdeDb.Imagen.TrimStart('\\'));

                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }


                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);

                    }
                    articuloVm.Producto.Imagen = @"imagenes\articulos" + nombreArchivo + extension;


                    _contenedor.Producto.Add(articuloVm.Producto);
                    _contenedor.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    articuloVm.Producto.Imagen = articuloDesdeDb.Imagen;
                    
                }
                _contenedor.Producto.Update(articuloVm.Producto);
                _contenedor.Save();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }


    }

    
}
