using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KonsiLoja.Contexto;
using KonsiLoja.Models;

namespace KonsiLoja.Controllers
{
    public class RelatorioGeralController : Controller
    {
        private readonly KonsiContexto _context;

        public RelatorioGeralController(KonsiContexto context)
        {
            _context = context;
        }

        // GET: RelatorioGeral
        public async Task<IActionResult> Index()
        {
            var konsiContexto = _context.RelatorioGeral.Include(r => r.Cliente).Include(r => r.Contrato).Include(r => r.Vendedor);
            return View(await konsiContexto.ToListAsync());
        }

        // GET: RelatorioGeral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioGeral = await _context.RelatorioGeral
                .Include(r => r.Cliente)
                .Include(r => r.Contrato)
                .Include(r => r.Vendedor)
                .FirstOrDefaultAsync(m => m.RelatorioGeralId == id);
            if (relatorioGeral == null)
            {
                return NotFound();
            }

            return View(relatorioGeral);
        }

        // GET: RelatorioGeral/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId");
            ViewData["VendedorId"] = new SelectList(_context.Vendedors, "VendedorId", "VendedorId");
            return View();
        }

        // POST: RelatorioGeral/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RelatorioGeralId,ClienteId,ContratoId,VendedorId")] RelatorioGeral relatorioGeral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatorioGeral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", relatorioGeral.ClienteId);
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", relatorioGeral.ContratoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedors, "VendedorId", "VendedorId", relatorioGeral.VendedorId);
            return View(relatorioGeral);
        }

        // GET: RelatorioGeral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioGeral = await _context.RelatorioGeral.FindAsync(id);
            if (relatorioGeral == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", relatorioGeral.ClienteId);
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", relatorioGeral.ContratoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedors, "VendedorId", "VendedorId", relatorioGeral.VendedorId);
            return View(relatorioGeral);
        }

        // POST: RelatorioGeral/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RelatorioGeralId,ClienteId,ContratoId,VendedorId")] RelatorioGeral relatorioGeral)
        {
            if (id != relatorioGeral.RelatorioGeralId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatorioGeral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorioGeralExists(relatorioGeral.RelatorioGeralId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", relatorioGeral.ClienteId);
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", relatorioGeral.ContratoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedors, "VendedorId", "VendedorId", relatorioGeral.VendedorId);
            return View(relatorioGeral);
        }

        // GET: RelatorioGeral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorioGeral = await _context.RelatorioGeral
                .Include(r => r.Cliente)
                .Include(r => r.Contrato)
                .Include(r => r.Vendedor)
                .FirstOrDefaultAsync(m => m.RelatorioGeralId == id);
            if (relatorioGeral == null)
            {
                return NotFound();
            }

            return View(relatorioGeral);
        }

        // POST: RelatorioGeral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatorioGeral = await _context.RelatorioGeral.FindAsync(id);
            _context.RelatorioGeral.Remove(relatorioGeral);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatorioGeralExists(int id)
        {
            return _context.RelatorioGeral.Any(e => e.RelatorioGeralId == id);
        }
    }
}
