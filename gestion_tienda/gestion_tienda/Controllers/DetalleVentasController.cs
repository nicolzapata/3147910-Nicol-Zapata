using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gestion_tienda.Models;

namespace gestion_tienda.Controllers
{
    public class DetalleVentasController : Controller
    {
        private readonly DbTiendaContext _context;

        public DetalleVentasController(DbTiendaContext context)
        {
            _context = context;
        }

        // GET: DetalleVentas
        public async Task<IActionResult> Index()
        {
            var detalles = _context.DetalleVentas!
                .Include(d => d.Producto)
                .Include(d => d.Venta);

            return View(await detalles.ToListAsync());
        }

        // GET: DetalleVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var detalle = await _context.DetalleVentas!
                .Include(d => d.Producto)
                .Include(d => d.Venta)
                .FirstOrDefaultAsync(m => m.Id == id.Value);

            return detalle == null ? NotFound() : View(detalle);
        }

        // GET: DetalleVentas/Create
        public IActionResult Create()
        {
            ViewBag.VentaId = new SelectList(_context.Ventas!, "Id", "Id");
            ViewBag.ProductoId = new SelectList(_context.Productos!, "Id", "Nombre");
            return View();
        }

        // POST: DetalleVentas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentaId,ProductoId,Cantidad")] DetalleVenta? detalle)
        {
            if (detalle is null)
                return BadRequest();

            var producto = await _context.Productos!.FindAsync(detalle.ProductoId);

            if (producto is null)
                ModelState.AddModelError("ProductoId", "Producto no encontrado.");

            if (detalle.Cantidad < 1)
                ModelState.AddModelError("Cantidad", "La cantidad debe ser mayor que 0.");

            if (producto != null && producto.Stock < detalle.Cantidad)
                ModelState.AddModelError("", $"Stock insuficiente. Disponible: {producto.Stock}");

            if (!ModelState.IsValid)
            {
                ViewBag.VentaId = new SelectList(_context.Ventas!, "Id", "Id", detalle.VentaId);
                ViewBag.ProductoId = new SelectList(_context.Productos!, "Id", "Nombre", detalle.ProductoId);
                return View(detalle);
            }

            detalle.PrecioUnitario = producto!.PrecioUnitario;

            using var tx = await _context.Database.BeginTransactionAsync();

            try
            {
                producto.Stock -= detalle.Cantidad;
                _context.Productos!.Update(producto);

                _context.DetalleVentas!.Add(detalle);
                await _context.SaveChangesAsync();

                var venta = await _context.Ventas!
                    .Include(v => v.DetalleVenta)
                    .FirstOrDefaultAsync(v => v.Id == detalle.VentaId);

                if (venta != null)
                {
                    venta.Total = venta.DetalleVenta.Sum(d => d.PrecioUnitario * d.Cantidad);
                    _context.Ventas!.Update(venta);
                    await _context.SaveChangesAsync();
                }

                await tx.CommitAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                await tx.RollbackAsync();
                ModelState.AddModelError("", "Error al guardar.");
                return View(detalle);
            }
        }

        // GET: DetalleVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var detalle = await _context.DetalleVentas!
                .Include(d => d.Producto)
                .Include(d => d.Venta)
                .FirstOrDefaultAsync(d => d.Id == id.Value);

            if (detalle == null)
                return NotFound();

            ViewBag.VentaId = new SelectList(_context.Ventas!, "Id", "Id", detalle.VentaId);
            ViewBag.ProductoId = new SelectList(_context.Productos!, "Id", "Nombre", detalle.ProductoId);

            return View(detalle);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VentaId,ProductoId,Cantidad,PrecioUnitario")] DetalleVenta detalle)
        {
            if (id != detalle.Id)
                return NotFound();

            var producto = await _context.Productos!.FindAsync(detalle.ProductoId);
            if (producto is null)
                ModelState.AddModelError("ProductoId", "Producto inválido.");

            if (detalle.Cantidad < 1)
                ModelState.AddModelError("Cantidad", "Debe ser mínimo 1.");

            if (!ModelState.IsValid)
            {
                ViewBag.VentaId = new SelectList(_context.Ventas!, "Id", "Id", detalle.VentaId);
                ViewBag.ProductoId = new SelectList(_context.Productos!, "Id", "Nombre", detalle.ProductoId);
                return View(detalle);
            }

            using var tx = await _context.Database.BeginTransactionAsync();

            try
            {
                var original = await _context.DetalleVentas!.AsNoTracking()
                    .FirstOrDefaultAsync(d => d.Id == id);

                if (original == null)
                    return NotFound();

                // Si cambió el producto
                if (original.ProductoId != detalle.ProductoId)
                {
                    var prodOriginal = await _context.Productos!.FindAsync(original.ProductoId);
                    if (prodOriginal != null)
                    {
                        prodOriginal.Stock += original.Cantidad;
                        _context.Productos!.Update(prodOriginal);
                    }

                    if (producto!.Stock < detalle.Cantidad)
                    {
                        ModelState.AddModelError("", $"Stock insuficiente. Disponible: {producto.Stock}");
                        return View(detalle);
                    }

                    producto.Stock -= detalle.Cantidad;
                    _context.Productos!.Update(producto);
                }
                else
                {
                    int diferencia = detalle.Cantidad - original.Cantidad;

                    if (diferencia > 0)
                    {
                        if (producto!.Stock < diferencia)
                        {
                            ModelState.AddModelError("", $"Stock insuficiente. Disponible: {producto.Stock}");
                            return View(detalle);
                        }
                        producto.Stock -= diferencia;
                        _context.Productos!.Update(producto);
                    }
                    else if (diferencia < 0)
                    {
                        producto!.Stock += (-diferencia);
                        _context.Productos!.Update(producto);
                    }
                }

                // Mantener precio unitario original
                _context.DetalleVentas!.Update(detalle);
                await _context.SaveChangesAsync();

                // Recalcular total
                var venta = await _context.Ventas!
                    .Include(v => v.DetalleVenta)
                    .FirstOrDefaultAsync(v => v.Id == detalle.VentaId);

                venta!.Total = venta.DetalleVenta.Sum(d => d.PrecioUnitario * d.Cantidad);
                _context.Ventas!.Update(venta);
                await _context.SaveChangesAsync();

                await tx.CommitAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                await tx.RollbackAsync();
                ModelState.AddModelError("", "Ocurrió un error al editar.");
                return View(detalle);
            }
        }

        // GET: DetalleVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var detalle = await _context.DetalleVentas!
                .Include(d => d.Producto)
                .Include(d => d.Venta)
                .FirstOrDefaultAsync(m => m.Id == id.Value);

            return detalle == null ? NotFound() : View(detalle);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalle = await _context.DetalleVentas!.FindAsync(id);

            if (detalle != null)
            {
                var producto = await _context.Productos!.FindAsync(detalle.ProductoId);
                if (producto != null)
                {
                    producto.Stock += detalle.Cantidad;
                    _context.Productos!.Update(producto);
                }

                _context.DetalleVentas.Remove(detalle);
                await _context.SaveChangesAsync();

                var venta = await _context.Ventas!
                    .Include(v => v.DetalleVenta)
                    .FirstOrDefaultAsync(v => v.Id == detalle.VentaId);

                if (venta != null)
                {
                    venta.Total = venta.DetalleVenta.Sum(d => d.PrecioUnitario * d.Cantidad);
                    _context.Ventas!.Update(venta);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private bool DetalleVentaExists(int id)
        {
            return _context.DetalleVentas!.Any(e => e.Id == id);
        }
    }
}
