using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagementSystem;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class OrdenComprasController : Controller
    {
        private readonly InventoryContext _context;

        public OrdenComprasController(InventoryContext context)
        {
            _context = context;
        }

        // GET: OrdenCompras
        public async Task<IActionResult> Index()
        {
            var inventoryContext = _context.OrdenesCompra.Include(o => o.Producto).Include(o => o.Proveedor);
            return View(await inventoryContext.ToListAsync());
        }

        // GET: OrdenCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenesCompra
                .Include(o => o.Producto)
                .Include(o => o.Proveedor)
                .FirstOrDefaultAsync(m => m.OrdenCompraId == id);
            if (ordenCompra == null)
            {
                return NotFound();
            }

            return View(ordenCompra);
        }

        // GET: OrdenCompras/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId");
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "ProveedorId");
            return View();
        }

        // POST: OrdenCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrdenCompraId,ProveedorId,ProductoId,Cantidad,FechaOrden")] OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", ordenCompra.ProductoId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "ProveedorId", ordenCompra.ProveedorId);
            return View(ordenCompra);
        }

        // GET: OrdenCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenesCompra.FindAsync(id);
            if (ordenCompra == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", ordenCompra.ProductoId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "ProveedorId", ordenCompra.ProveedorId);
            return View(ordenCompra);
        }

        // POST: OrdenCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrdenCompraId,ProveedorId,ProductoId,Cantidad,FechaOrden")] OrdenCompra ordenCompra)
        {
            if (id != ordenCompra.OrdenCompraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenCompraExists(ordenCompra.OrdenCompraId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", ordenCompra.ProductoId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "ProveedorId", ordenCompra.ProveedorId);
            return View(ordenCompra);
        }

        // GET: OrdenCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenesCompra
                .Include(o => o.Producto)
                .Include(o => o.Proveedor)
                .FirstOrDefaultAsync(m => m.OrdenCompraId == id);
            if (ordenCompra == null)
            {
                return NotFound();
            }

            return View(ordenCompra);
        }

        // POST: OrdenCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenCompra = await _context.OrdenesCompra.FindAsync(id);
            if (ordenCompra != null)
            {
                _context.OrdenesCompra.Remove(ordenCompra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenCompraExists(int id)
        {
            return _context.OrdenesCompra.Any(e => e.OrdenCompraId == id);
        }
    }
}
