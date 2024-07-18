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
    public class FilmDTOesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmDTOesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FilmDTOes
        public async Task<IActionResult> Index()
        {
              return _context.FilmDTOs != null ? 
                          View(await _context.FilmDTOs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.FilmDTOs'  is null.");
        }

        // GET: FilmDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FilmDTOs == null)
            {
                return NotFound();
            }

            var filmDTO = await _context.FilmDTOs
                .FirstOrDefaultAsync(m => m.idFilm == id);
            if (filmDTO == null)
            {
                return NotFound();
            }

            return View(filmDTO);
        }

        // GET: FilmDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idFilm,nom,categorie")] FilmDTO filmDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmDTO);
        }

        // GET: FilmDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FilmDTOs == null)
            {
                return NotFound();
            }

            var filmDTO = await _context.FilmDTOs.FindAsync(id);
            if (filmDTO == null)
            {
                return NotFound();
            }
            return View(filmDTO);
        }

        // POST: FilmDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idFilm,nom,categorie")] FilmDTO filmDTO)
        {
            if (id != filmDTO.idFilm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmDTOExists(filmDTO.idFilm))
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
            return View(filmDTO);
        }

        // GET: FilmDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FilmDTOs == null)
            {
                return NotFound();
            }

            var filmDTO = await _context.FilmDTOs
                .FirstOrDefaultAsync(m => m.idFilm == id);
            if (filmDTO == null)
            {
                return NotFound();
            }

            return View(filmDTO);
        }

        // POST: FilmDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FilmDTOs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FilmDTOs'  is null.");
            }
            var filmDTO = await _context.FilmDTOs.FindAsync(id);
            if (filmDTO != null)
            {
                _context.FilmDTOs.Remove(filmDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmDTOExists(int id)
        {
          return (_context.FilmDTOs?.Any(e => e.idFilm == id)).GetValueOrDefault();
        }
    }
}
