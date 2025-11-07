using CrudNativo.Data;
using CrudNativo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CrudNativo.Controllers
{
    public class ProductoController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Metodo GET----------------------------------------------
        public ActionResult Index()
        {
            IEnumerable<Producto> ListaProductos = _context.Productos;
            return View(ListaProductos);
        }
        //Metodo GET Crear-----------------------------------------
        public ActionResult Crear()
        {
            return View();
        }
        //Metodo POST Crear-----------------------------------------
        [HttpPost]
        public IActionResult Crear(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return View(producto);
            }
            return View(producto);
        }

            //Metodo GET edit---------------------------------------
            public IActionResult Editar(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var producto = _context.Productos.Find(id);
                if (producto == null)
                {
                    return NotFound();
                }
                return View(producto);
            }

            //Metodo Post editar--------------------------------------
            [HttpPost]

            public IActionResult Editar(Producto producto) 
            {
                if (ModelState.IsValid) 
                {
                    _context.Productos.Update(producto);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(producto);
            }

            //Metodo GET Delete--------------------------------------
            [HttpPost]

            public IActionResult Delete(int? id)
            {
               var producto = _context.Productos.Find(id);
                if (producto == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Productos.Remove(producto);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
    } 
}

