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
    public class ContratosController : Controller
    {
        private readonly KonsiContexto _context;

        public ContratosController(KonsiContexto context)
        {
            _context = context;
        }

        // GET: Contratos
        public  IActionResult Index( decimal ? devedor , decimal ? parcelasPagas)
        {
            var ListsPesquisa = _context.Contratos.Where(x => x.SaldoDevedor > devedor || x.ParcelasPagas < parcelasPagas && x.Vendedores.Nome != null).ToList();

            return View(ListsPesquisa);
        }

        // GET: Contratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.Clientes)
                .Include(c => c.Vendedores)
                .FirstOrDefaultAsync(m => m.ContratoId == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // GET: Contratos/Create
        public IActionResult Create()
        {
            ViewBag.CPF = new SelectList(_context.Clientes, "ClienteId", "CPF");
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClienteId", "Nome");
            ViewData["VendedoresId"] = new SelectList(_context.Vendedors, "VendedorId", "Nome");
            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContratoId,NumeroContrato,ValorContrato,SaldoDevedor,ParcelasTotais,ParcelasPagas,ValorParcela,VendedoresId,ClientesId")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CPF = new SelectList(_context.Clientes, "ClienteId", "CPF", contrato.ClientesId);
            ViewBag.ClientesId = new SelectList(_context.Clientes, "ClienteId", "Nome", contrato.ClientesId);
            ViewBag.VendedoresId = new SelectList(_context.Vendedors, "VendedorId", "Nome", contrato.VendedoresId);
            return View(contrato);
        }

        // GET: Contratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", contrato.ClientesId);
            ViewData["VendedoresId"] = new SelectList(_context.Vendedors, "VendedorId", "VendedorId", contrato.VendedoresId);
            return View(contrato);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContratoId,NumeroContrato,ValorContrato,SaldoDevedor,ParcelasTotais,ParcelasPagas,ValorParcela,VendedoresId,ClientesId")] Contrato contrato)
        {
            if (id != contrato.ContratoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoExists(contrato.ContratoId))
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
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", contrato.ClientesId);
            ViewData["VendedoresId"] = new SelectList(_context.Vendedors, "VendedorId", "VendedorId", contrato.VendedoresId);
            return View(contrato);
        }

        // GET: Contratos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.Clientes)
                .Include(c => c.Vendedores)
                .FirstOrDefaultAsync(m => m.ContratoId == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contrato = await _context.Contratos.FindAsync(id);
            _context.Contratos.Remove(contrato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoExists(int id)
        {
            return _context.Contratos.Any(e => e.ContratoId == id);
        }
    }
}
