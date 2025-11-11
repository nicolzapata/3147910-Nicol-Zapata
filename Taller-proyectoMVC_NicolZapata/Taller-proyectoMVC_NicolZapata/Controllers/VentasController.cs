using Microsoft.AspNetCore.Mvc;
using Taller_proyectoMVC_NicolZapata.Data;
using Taller_proyectoMVC_NicolZapata.Models;
using Microsoft.EntityFrameworkCore;

namespace Taller_proyectoMVC_NicolZapata.Controllers
{
    public class VentaController : Controller
    {
            private readonly ApplicationDbContext _context;
        public VentaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var ventas = await _context.Venta
                .Include(v => v.Cliente)
                .Include(v => v.Producto)
                .ToListAsync();


                return View(ventas);
        }

        public IActionResult Create()
            { return View(); }
        [HttpPost]
        public async Task<IActionResult> Create(Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venta);
        }
    }
}

