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
    public class PrevisionsController : Controller
    {
        private readonly AssurancesContext _context;

        public PrevisionsController(AssurancesContext context)
        {
            _context = context;
        }

        // GET: Previsions
        public async Task<IActionResult> Index()
        {
            var assurancesContext = _context.Previsions.Include(p => p.CodeForNavigation).Include(p => p.CodeGarNavigation);
            return View(await assurancesContext.ToListAsync());
        }

        // GET: Previsions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Previsions == null)
            {
                return NotFound();
            }

            var prevision = await _context.Previsions
                .Include(p => p.CodeForNavigation)
                .Include(p => p.CodeGarNavigation)
                .FirstOrDefaultAsync(m => m.CodeProvision == id);
            if (prevision == null)
            {
                return NotFound();
            }

            return View(prevision);
        }

        // GET: Previsions/Create
        public IActionResult Create()
        {
            ViewData["CodeFor"] = new SelectList(_context.Formules, "CodeFormule", "CodeFormule");
            ViewData["CodeGar"] = new SelectList(_context.Garanties, "CodeGarantie", "CodeGarantie");
            return View();
        }

        // POST: Previsions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodeProvision,CodeFor,CodeGar,PlafondFranchie")] Prevision prevision)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prevision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodeFor"] = new SelectList(_context.Formules, "CodeFormule", "CodeFormule", prevision.CodeFor);
            ViewData["CodeGar"] = new SelectList(_context.Garanties, "CodeGarantie", "CodeGarantie", prevision.CodeGar);
            return View(prevision);
        }

        // GET: Previsions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Previsions == null)
            {
                return NotFound();
            }

            var prevision = await _context.Previsions.FindAsync(id);
            if (prevision == null)
            {
                return NotFound();
            }
            ViewData["CodeFor"] = new SelectList(_context.Formules, "CodeFormule", "CodeFormule", prevision.CodeFor);
            ViewData["CodeGar"] = new SelectList(_context.Garanties, "CodeGarantie", "CodeGarantie", prevision.CodeGar);
            return View(prevision);
        }

        // POST: Previsions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodeProvision,CodeFor,CodeGar,PlafondFranchie")] Prevision prevision)
        {
            if (id != prevision.CodeProvision)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prevision);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrevisionExists(prevision.CodeProvision))
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
            ViewData["CodeFor"] = new SelectList(_context.Formules, "CodeFormule", "CodeFormule", prevision.CodeFor);
            ViewData["CodeGar"] = new SelectList(_context.Garanties, "CodeGarantie", "CodeGarantie", prevision.CodeGar);
            return View(prevision);
        }

        // GET: Previsions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Previsions == null)
            {
                return NotFound();
            }

            var prevision = await _context.Previsions
                .Include(p => p.CodeForNavigation)
                .Include(p => p.CodeGarNavigation)
                .FirstOrDefaultAsync(m => m.CodeProvision == id);
            if (prevision == null)
            {
                return NotFound();
            }

            return View(prevision);
        }

        // POST: Previsions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Previsions == null)
            {
                return Problem("Entity set 'AssurancesContext.Previsions'  is null.");
            }
            var prevision = await _context.Previsions.FindAsync(id);
            if (prevision != null)
            {
                _context.Previsions.Remove(prevision);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrevisionExists(int id)
        {
          return (_context.Previsions?.Any(e => e.CodeProvision == id)).GetValueOrDefault();
        }
    }
}
