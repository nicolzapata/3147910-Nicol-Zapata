using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gestion_tienda.Models;

namespace gestion_tienda.Controllers
{
    public class VentasController : Controller
    {
        private readonly DbTiendaContext _context;

        public VentasController(DbTiendaContext context)
        {
            _context = context;
        }

        // -------------------------------------------------------------
        // INDEX (con filtros y SIN advertencias por null)
        // -------------------------------------------------------------
        public async Task<IActionResult> Index(string? clienteNombre, DateTime? desde, DateTime? hasta)
        {
            var query = _context.Ventas
                .Include(v => v.Cliente)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(clienteNombre))
            {
                query = query.Where(v =>
                    v.Cliente != null &&
                    v.Cliente.NombreCompleto.Contains(clienteNombre)
                );
            }

            if (desde.HasValue)
            {
                query = query.Where(v => v.Fecha >= desde.Value);
            }

            if (hasta.HasValue)
            {
                query = query.Where(v => v.Fecha <= hasta.Value);
            }

            return View(await query
                .OrderByDescending(v => v.Fecha)
                .ToListAsync());
        }

        // -------------------------------------------------------------
        // DETAILS
        // -------------------------------------------------------------
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.DetalleVenta)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (venta == null)
                return NotFound();

            return View(venta);
        }

        // -------------------------------------------------------------
        // GET: CREATE
        // -------------------------------------------------------------
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto");

            var productos = _context.Productos
                .OrderBy(p => p.Nombre)
                .Select(p => new VentaItemViewModel
                {
                    ProductoId = p.Id,
                    ProductoNombre = p.Nombre,
                    PrecioUnitario = p.PrecioUnitario,
                    Cantidad = 0
                })
                .ToList();

            var vm = new VentaCreateViewModel
            {
                Items = productos
            };

            return View(vm);
        }

        // -------------------------------------------------------------
        // POST: CREATE
        // -------------------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VentaCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto", model.ClienteId);
                return View(model);
            }

            // Items válidos
            var items = model.Items.Where(i => i.Cantidad > 0).ToList();
            if (!items.Any())
            {
                ModelState.AddModelError("", "Debes seleccionar al menos un producto con cantidad mayor a 0.");
                ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto", model.ClienteId);
                return View(model);
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Lista de IDs de productos
                var ids = items.Select(i => i.ProductoId).ToList();

                // Cargar productos reales
                var productosDb = await _context.Productos
                    .Where(p => ids.Contains(p.Id))
                    .ToDictionaryAsync(p => p.Id);

                // Validaciones de stock
                foreach (var it in items)
                {
                    if (!productosDb.TryGetValue(it.ProductoId, out var prod))
                    {
                        ModelState.AddModelError("", $"Producto no encontrado (ID {it.ProductoId}).");
                        return View(model);
                    }

                    if (prod.Stock < it.Cantidad)
                    {
                        ModelState.AddModelError("", $"Stock insuficiente para {prod.Nombre}. Disponible: {prod.Stock}.");
                        return View(model);
                    }
                }

                // Crear venta
                var venta = new Venta
                {
                    ClienteId = model.ClienteId,
                    Fecha = model.Fecha,
                    Total = 0
                };

                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();

                decimal total = 0;

                // Crear detalles
                foreach (var it in items)
                {
                    var prod = productosDb[it.ProductoId];
                    var precio = prod.PrecioUnitario;
                    var subtotal = precio * it.Cantidad;

                    var det = new DetalleVenta
                    {
                        VentaId = venta.Id,
                        ProductoId = prod.Id,
                        Cantidad = it.Cantidad,
                        PrecioUnitario = precio
                    };

                    _context.DetalleVentas.Add(det);

                    // Actualizar stock
                    prod.Stock -= it.Cantidad;
                    _context.Productos.Update(prod);

                    total += subtotal;
                }

                venta.Total = total;
                _context.Ventas.Update(venta);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return RedirectToAction(nameof(Details), new { id = venta.Id });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                ModelState.AddModelError("", "Error al crear venta: " + ex.Message);
                ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto", model.ClienteId);
                return View(model);
            }
        }

        // -------------------------------------------------------------
        // EDIT (mantienes tus versiones)
        // -------------------------------------------------------------
        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.DetalleVenta)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (venta == null)
                return NotFound();

            return View(venta);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Venta venta)
        {
            if (id != venta.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Ventas.Any(e => e.Id == venta.Id))
                        return NotFound();

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(venta);
        }


        // -------------------------------------------------------------
        // DELETE (mantienes tus versiones)
        // -------------------------------------------------------------

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (venta == null)
                return NotFound();

            return View(venta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas
                .Include(v => v.DetalleVenta)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (venta == null)
                return NotFound();

            // Restaurar stock
            foreach (var det in venta.DetalleVenta)
            {
                var producto = await _context.Productos.FindAsync(det.ProductoId);
                if (producto != null)
                {
                    producto.Stock += det.Cantidad;
                    _context.Productos.Update(producto);
                }
            }

            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
