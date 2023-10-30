using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tp7.Models;

namespace tp7.Controllers
{
    public class ContratsController : Controller
    {
        private readonly AssurancesContext _context;

        public ContratsController(AssurancesContext context)
        {
            _context = context;
        }

        // GET: Contrats
        public async Task<IActionResult> Index()
        {
            var assurancesContext = _context.Contrats.Include(c => c.IdClientNavigation).Include(c => c.NumForNavigation);
            return View(await assurancesContext.ToListAsync());
        }

        // GET: Contrats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contrats == null)
            {
                return NotFound();
            }

            var contrat = await _context.Contrats
                .Include(c => c.IdClientNavigation)
                .Include(c => c.NumForNavigation)
                .FirstOrDefaultAsync(m => m.Num == id);
            if (contrat == null)
            {
                return NotFound();
            }

            return View(contrat);
        }

        // GET: Contrats/Create
        public IActionResult Create()
        {
            ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Id");
            ViewData["NumFor"] = new SelectList(_context.Formules, "CodeFormule", "CodeFormule");
            return View();
        }

        // POST: Contrats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Num,DateSouscription,DateEcheance,IdClient,NumFor")] Contrat contrat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contrat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Id", contrat.IdClient);
            ViewData["NumFor"] = new SelectList(_context.Formules, "CodeFormule", "CodeFormule", contrat.NumFor);
            return View(contrat);
        }

        // GET: Contrats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contrats == null)
            {
                return NotFound();
            }

            var contrat = await _context.Contrats.FindAsync(id);
            if (contrat == null)
            {
                return NotFound();
            }
            ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Id", contrat.IdClient);
            ViewData["NumFor"] = new SelectList(_context.Formules, "CodeFormule", "CodeFormule", contrat.NumFor);
            return View(contrat);
        }

        // POST: Contrats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Num,DateSouscription,DateEcheance,IdClient,NumFor")] Contrat contrat)
        {
            if (id != contrat.Num)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratExists(contrat.Num))
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
            ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Id", contrat.IdClient);
            ViewData["NumFor"] = new SelectList(_context.Formules, "CodeFormule", "CodeFormule", contrat.NumFor);
            return View(contrat);
        }

        // GET: Contrats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contrats == null)
            {
                return NotFound();
            }

            var contrat = await _context.Contrats
                .Include(c => c.IdClientNavigation)
                .Include(c => c.NumForNavigation)
                .FirstOrDefaultAsync(m => m.Num == id);
            if (contrat == null)
            {
                return NotFound();
            }

            return View(contrat);
        }

        // POST: Contrats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contrats == null)
            {
                return Problem("Entity set 'AssurancesContext.Contrats'  is null.");
            }
            var contrat = await _context.Contrats.FindAsync(id);
            if (contrat != null)
            {
                _context.Contrats.Remove(contrat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratExists(int id)
        {
          return (_context.Contrats?.Any(e => e.Num == id)).GetValueOrDefault();
        }
    }
}
