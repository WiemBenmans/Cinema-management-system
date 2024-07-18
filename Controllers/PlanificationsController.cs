using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cinema.data;

namespace cinema.Controllers
{
    public class PlanificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlanificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Planifications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.planifications.Include(p => p.Film).Include(p => p.Salle)
                ;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Planifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.planifications == null)
            {
                return NotFound();
            }

            var planification = await _context.planifications
                .Include(p => p.Film)
                .Include(p => p.Salle) 
                .Include(p=>p.IdDate)
                .FirstOrDefaultAsync(m => m.id == id);
            if (planification == null)
            {
                return NotFound();
            }

            return View(planification);
        }

        // GET: Planifications/Create
        public IActionResult Create()
        {
            ViewData["FilmId"] = new SelectList(_context.FilmDTOs, "idFilm", "nom");
            ViewData["SalleId"] = new SelectList(_context.salleDTOs, "id", "id");
            ViewData["IdDate"] = new SelectList(_context.Date, "Id", "DateText");

            return View();
        }

        // POST: Planifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FilmId,SalleId,IdDate,prixticket")] Planification planification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmId"] = new SelectList(_context.FilmDTOs, "idFilm", "idFilm", planification.FilmId);
            ViewData["SalleId"] = new SelectList(_context.salleDTOs, "id", "id", planification.SalleId);
            ViewData["IdDate"] = new SelectList(_context.Date, "Id", "Id", planification.IdDate);
            return View(planification);
        }

        // GET: Planifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.planifications == null)
            {
                return NotFound();
            }

            var planification = await _context.planifications.FindAsync(id);
            if (planification == null)
            {
                return NotFound();
            }
            ViewData["FilmId"] = new SelectList(_context.FilmDTOs, "idFilm", "idFilm", planification.FilmId);
            ViewData["SalleId"] = new SelectList(_context.salleDTOs, "id", "id", planification.SalleId);
            ViewData["IdDate"] = new SelectList(_context.Date, "Id", "Id", planification.IdDate);
            return View(planification);
        }

        // POST: Planifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FilmId,SalleId,IdDate,prixticket")] Planification planification)
        {
            if (id != planification.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanificationExists(planification.id))
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
            ViewData["FilmId"] = new SelectList(_context.FilmDTOs, "idFilm", "idFilm", planification.FilmId);
            ViewData["SalleId"] = new SelectList(_context.salleDTOs, "id", "id", planification.SalleId);
            ViewData["IdDate"] = new SelectList(_context.Date, "Id", "Id", planification.IdDate);
            return View(planification);
        }

        // GET: Planifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.planifications == null)
            {
                return NotFound();
            }

            var planification = await _context.planifications
                .Include(p => p.Film)
                .Include(p => p.Salle)
                 .Include(p => p.IdDate) 
                .FirstOrDefaultAsync(m => m.id == id);
            if (planification == null)
            {
                return NotFound();
            }

            return View(planification);
        }

        // POST: Planifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.planifications == null)
            {
                return Problem("Entity set 'ApplicationDbContext.planifications'  is null.");
            }
            var planification = await _context.planifications.FindAsync(id);
            if (planification != null)
            {
                _context.planifications.Remove(planification);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanificationExists(int id)
        {
          return (_context.planifications?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
