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
    public class AgresController : Controller
    {
        private readonly BdGymnastiqueContext _context;

        public AgresController(BdGymnastiqueContext context)
        {
            _context = context;
        }

        // GET: Agres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agres.ToListAsync());
        }

        // GET: Agres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agre = await _context.Agres
                .FirstOrDefaultAsync(m => m.AgreId == id);
            if (agre == null)
            {
                return NotFound();
            }

            return View(agre);
        }

        // GET: Agres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgreId,Nom")] Agre agre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agre);
        }

        // GET: Agres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agre = await _context.Agres.FindAsync(id);
            if (agre == null)
            {
                return NotFound();
            }
            return View(agre);
        }

        // POST: Agres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgreId,Nom")] Agre agre)
        {
            if (id != agre.AgreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgreExists(agre.AgreId))
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
            return View(agre);
        }

        // GET: Agres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agre = await _context.Agres
                .FirstOrDefaultAsync(m => m.AgreId == id);
            if (agre == null)
            {
                return NotFound();
            }

            return View(agre);
        }

        // POST: Agres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agre = await _context.Agres.FindAsync(id);
            if (agre != null)
            {
                _context.Agres.Remove(agre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgreExists(int id)
        {
            return _context.Agres.Any(e => e.AgreId == id);
        }
    }
}
