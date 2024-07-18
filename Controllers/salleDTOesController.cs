using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cinema.Model;
using cinema.data;

namespace cinema.Controllers
{
    public class salleDTOesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public salleDTOesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: salleDTOes
        public async Task<IActionResult> Index()
        {
              return _context.salleDTOs != null ? 
                          View(await _context.salleDTOs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.salleDTOs'  is null.");
        }

        // GET: salleDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.salleDTOs == null)
            {
                return NotFound();
            }

            var salleDTO = await _context.salleDTOs
                .FirstOrDefaultAsync(m => m.id == id);
            if (salleDTO == null)
            {
                return NotFound();
            }

            return View(salleDTO);
        }

        // GET: salleDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: salleDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,statut,nombrePlaces")] salleDTO salleDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salleDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salleDTO);
        }

        // GET: salleDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.salleDTOs == null)
            {
                return NotFound();
            }

            var salleDTO = await _context.salleDTOs.FindAsync(id);
            if (salleDTO == null)
            {
                return NotFound();
            }
            return View(salleDTO);
        }

        // POST: salleDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,statut,nombrePlaces,Positions")] salleDTO salleDTO)
        {
            if (id != salleDTO.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salleDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!salleDTOExists(salleDTO.id))
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
            return View(salleDTO);
        }

        // GET: salleDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.salleDTOs == null)
            {
                return NotFound();
            }

            var salleDTO = await _context.salleDTOs
                .FirstOrDefaultAsync(m => m.id == id);
            if (salleDTO == null)
            {
                return NotFound();
            }

            return View(salleDTO);
        }

        // POST: salleDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.salleDTOs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.salleDTOs'  is null.");
            }
            var salleDTO = await _context.salleDTOs.FindAsync(id);
            if (salleDTO != null)
            {
                _context.salleDTOs.Remove(salleDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool salleDTOExists(int id)
        {
          return (_context.salleDTOs?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
