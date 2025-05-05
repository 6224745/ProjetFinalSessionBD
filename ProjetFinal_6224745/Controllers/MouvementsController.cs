using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_6224745.Data;
using ProjetFinal_6224745.Models;

namespace ProjetFinal_6224745.Controllers
{
    public class MouvementsController : Controller
    {
        private readonly BdGymnastiqueContext _context;

        public MouvementsController(BdGymnastiqueContext context)
        {
            _context = context;
        }

        // GET: Mouvements
        public async Task<IActionResult> Index()
        {
            var bdGymnastiqueContext = _context.Mouvements.Include(m => m.Agre);
            return View(await bdGymnastiqueContext.ToListAsync());
        }

        // GET: Mouvements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouvement = await _context.Mouvements
                .Include(m => m.Agre)
                .FirstOrDefaultAsync(m => m.MouvementId == id);
            if (mouvement == null)
            {
                return NotFound();
            }

            return View(mouvement);
        }

        // GET: Mouvements/Create
        public IActionResult Create()
        {
            ViewData["AgreId"] = new SelectList(_context.Agres, "AgreId", "AgreId");
            return View();
        }

        // POST: Mouvements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MouvementId,Nom,Difficulte,Valeur,Description,AgreId")] Mouvement mouvement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mouvement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgreId"] = new SelectList(_context.Agres, "AgreId", "AgreId", mouvement.AgreId);
            return View(mouvement);
        }

        // GET: Mouvements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouvement = await _context.Mouvements.FindAsync(id);
            if (mouvement == null)
            {
                return NotFound();
            }
            ViewData["AgreId"] = new SelectList(_context.Agres, "AgreId", "AgreId", mouvement.AgreId);
            return View(mouvement);
        }

        // POST: Mouvements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MouvementId,Nom,Difficulte,Valeur,Description,AgreId")] Mouvement mouvement)
        {
            if (id != mouvement.MouvementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mouvement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MouvementExists(mouvement.MouvementId))
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
            ViewData["AgreId"] = new SelectList(_context.Agres, "AgreId", "AgreId", mouvement.AgreId);
            return View(mouvement);
        }

        // GET: Mouvements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouvement = await _context.Mouvements
                .Include(m => m.Agre)
                .FirstOrDefaultAsync(m => m.MouvementId == id);
            if (mouvement == null)
            {
                return NotFound();
            }

            return View(mouvement);
        }

        // POST: Mouvements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mouvement = await _context.Mouvements.FindAsync(id);
            if (mouvement != null)
            {
                _context.Mouvements.Remove(mouvement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MouvementExists(int id)
        {
            return _context.Mouvements.Any(e => e.MouvementId == id);
        }
    }
}
