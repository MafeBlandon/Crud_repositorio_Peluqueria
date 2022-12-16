using AccesoDatos.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Modelos;

namespace completoOne.Areas.Admin.Controllers
{
    [Area("Admin")]
    //con todas las tablas 
    public class CategoriaController : Controller
    {
        private readonly Icontenedor _contenedor;

        public CategoriaController(Icontenedor contenedor)
        {
            _contenedor = contenedor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contenedor.Categoria.Add(categoria);
                _contenedor.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(categoria);
        }


        #region LLAMADAS A LAS API
        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new { data = _contenedor.Categoria.GetAll() });
        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedor.Categoria.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando categoria" });

            }
            _contenedor.Categoria.Remove(objFromDb);
            _contenedor.Save();
            return Json(new { success = true, message = "Categoria borrada correctamente " });

        }
        #endregion

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Categoria categoria = new Categoria();
            categoria = _contenedor.Categoria.Get(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contenedor.Categoria.Update(categoria);
                _contenedor.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(categoria);
        }


    }
}
