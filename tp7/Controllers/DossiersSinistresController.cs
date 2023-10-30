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
    public class DossiersSinistresController : Controller
    {
        private readonly AssurancesContext _context;

        public DossiersSinistresController(AssurancesContext context)
        {
            _context = context;
        }

        // GET: DossiersSinistres
        public async Task<IActionResult> Index()
        {
            var assurancesContext = _context.DossiersSinistres.Include(d => d.IdExpertNavigation).Include(d => d.IdcorrespondantNavigation).Include(d => d.NumContratNavigation);
            return View(await assurancesContext.ToListAsync());
        }

        // GET: DossiersSinistres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DossiersSinistres == null)
            {
                return NotFound();
            }

            var dossiersSinistre = await _context.DossiersSinistres
                .Include(d => d.IdExpertNavigation)
                .Include(d => d.IdcorrespondantNavigation)
                .Include(d => d.NumContratNavigation)
                .FirstOrDefaultAsync(m => m.CodeDossier == id);
            if (dossiersSinistre == null)
            {
                return NotFound();
            }

            return View(dossiersSinistre);
        }

        // GET: DossiersSinistres/Create
        public IActionResult Create()
        {
            ViewData["IdExpert"] = new SelectList(_context.Experts, "IdExpert", "IdExpert");
            ViewData["Idcorrespondant"] = new SelectList(_context.Correspondants, "IdCorrespondant", "IdCorrespondant");
            ViewData["NumContrat"] = new SelectList(_context.Contrats, "Num", "Num");
            return View();
        }

        // POST: DossiersSinistres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodeDossier,DateOuverture,DateCloture,Indemnite,NumContrat,Idcorrespondant,IdExpert")] DossiersSinistre dossiersSinistre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dossiersSinistre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdExpert"] = new SelectList(_context.Experts, "IdExpert", "IdExpert", dossiersSinistre.IdExpert);
            ViewData["Idcorrespondant"] = new SelectList(_context.Correspondants, "IdCorrespondant", "IdCorrespondant", dossiersSinistre.Idcorrespondant);
            ViewData["NumContrat"] = new SelectList(_context.Contrats, "Num", "Num", dossiersSinistre.NumContrat);
            return View(dossiersSinistre);
        }

        // GET: DossiersSinistres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DossiersSinistres == null)
            {
                return NotFound();
            }

            var dossiersSinistre = await _context.DossiersSinistres.FindAsync(id);
            if (dossiersSinistre == null)
            {
                return NotFound();
            }
            ViewData["IdExpert"] = new SelectList(_context.Experts, "IdExpert", "IdExpert", dossiersSinistre.IdExpert);
            ViewData["Idcorrespondant"] = new SelectList(_context.Correspondants, "IdCorrespondant", "IdCorrespondant", dossiersSinistre.Idcorrespondant);
            ViewData["NumContrat"] = new SelectList(_context.Contrats, "Num", "Num", dossiersSinistre.NumContrat);
            return View(dossiersSinistre);
        }

        // POST: DossiersSinistres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodeDossier,DateOuverture,DateCloture,Indemnite,NumContrat,Idcorrespondant,IdExpert")] DossiersSinistre dossiersSinistre)
        {
            if (id != dossiersSinistre.CodeDossier)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dossiersSinistre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DossiersSinistreExists(dossiersSinistre.CodeDossier))
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
            ViewData["IdExpert"] = new SelectList(_context.Experts, "IdExpert", "IdExpert", dossiersSinistre.IdExpert);
            ViewData["Idcorrespondant"] = new SelectList(_context.Correspondants, "IdCorrespondant", "IdCorrespondant", dossiersSinistre.Idcorrespondant);
            ViewData["NumContrat"] = new SelectList(_context.Contrats, "Num", "Num", dossiersSinistre.NumContrat);
            return View(dossiersSinistre);
        }

        // GET: DossiersSinistres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DossiersSinistres == null)
            {
                return NotFound();
            }

            var dossiersSinistre = await _context.DossiersSinistres
                .Include(d => d.IdExpertNavigation)
                .Include(d => d.IdcorrespondantNavigation)
                .Include(d => d.NumContratNavigation)
                .FirstOrDefaultAsync(m => m.CodeDossier == id);
            if (dossiersSinistre == null)
            {
                return NotFound();
            }

            return View(dossiersSinistre);
        }

        // POST: DossiersSinistres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DossiersSinistres == null)
            {
                return Problem("Entity set 'AssurancesContext.DossiersSinistres'  is null.");
            }
            var dossiersSinistre = await _context.DossiersSinistres.FindAsync(id);
            if (dossiersSinistre != null)
            {
                _context.DossiersSinistres.Remove(dossiersSinistre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DossiersSinistreExists(int id)
        {
          return (_context.DossiersSinistres?.Any(e => e.CodeDossier == id)).GetValueOrDefault();
        }
    }
}
