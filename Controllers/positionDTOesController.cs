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
    public class positionDTOesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public positionDTOesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: positionDTOes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.positionDTOs.Include(p => p.Salle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: positionDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.positionDTOs == null)
            {
                return NotFound();
            }

            var positionDTO = await _context.positionDTOs
                .Include(p => p.Salle)
                .FirstOrDefaultAsync(m => m.idPos == id);
            if (positionDTO == null)
            {
                return NotFound();
            }

            return View(positionDTO);
        }

        // GET: positionDTOes/Create
        public IActionResult Create()
        {
            ViewData["SalleId"] = new SelectList(_context.salleDTOs, "id", "id");
            return View();
        }

        // POST: positionDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idPos,ligne,colonne,SalleId")] positionDTO positionDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(positionDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalleId"] = new SelectList(_context.salleDTOs, "id", "id", positionDTO.SalleId);
            return View(positionDTO);
        }

        // GET: positionDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.positionDTOs == null)
            {
                return NotFound();
            }

            var positionDTO = await _context.positionDTOs.FindAsync(id);
            if (positionDTO == null)
            {
                return NotFound();
            }
            ViewData["SalleId"] = new SelectList(_context.salleDTOs, "id", "id", positionDTO.SalleId);
            return View(positionDTO);
        }

        // POST: positionDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPos,ligne,colonne,SalleId")] positionDTO positionDTO)
        {
            if (id != positionDTO.idPos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(positionDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!positionDTOExists(positionDTO.idPos))
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
            ViewData["SalleId"] = new SelectList(_context.salleDTOs, "id", "id", positionDTO.SalleId);
            return View(positionDTO);
        }

        // GET: positionDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.positionDTOs == null)
            {
                return NotFound();
            }

            var positionDTO = await _context.positionDTOs
                .Include(p => p.Salle)
                .FirstOrDefaultAsync(m => m.idPos == id);
            if (positionDTO == null)
            {
                return NotFound();
            }

            return View(positionDTO);
        }

        // POST: positionDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.positionDTOs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.positionDTOs'  is null.");
            }
            var positionDTO = await _context.positionDTOs.FindAsync(id);
            if (positionDTO != null)
            {
                _context.positionDTOs.Remove(positionDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool positionDTOExists(int id)
        {
          return (_context.positionDTOs?.Any(e => e.idPos == id)).GetValueOrDefault();
        }
    }
}
