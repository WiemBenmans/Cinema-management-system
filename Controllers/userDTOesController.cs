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
    public class userDTOesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public userDTOesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: userDTOes
        public async Task<IActionResult> Index()
        {
              return _context.userDTO != null ? 
                          View(await _context.userDTO.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.userDTO'  is null.");
        }

        // GET: userDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.userDTO == null)
            {
                return NotFound();
            }

            var userDTO = await _context.userDTO
                .FirstOrDefaultAsync(m => m.id == id);
            if (userDTO == null)
            {
                return NotFound();
            }

            return View(userDTO);
        }

        // GET: userDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: userDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,email,Password")] userDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userDTO);
        }

        // GET: userDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.userDTO == null)
            {
                return NotFound();
            }

            var userDTO = await _context.userDTO.FindAsync(id);
            if (userDTO == null)
            {
                return NotFound();
            }
            return View(userDTO);
        }

        // POST: userDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,email,Password")] userDTO userDTO)
        {
            if (id != userDTO.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!userDTOExists(userDTO.id))
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
            return View(userDTO);
        }

        // GET: userDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.userDTO == null)
            {
                return NotFound();
            }

            var userDTO = await _context.userDTO
                .FirstOrDefaultAsync(m => m.id == id);
            if (userDTO == null)
            {
                return NotFound();
            }

            return View(userDTO);
        }

        // POST: userDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.userDTO == null)
            {
                return Problem("Entity set 'ApplicationDbContext.userDTO'  is null.");
            }
            var userDTO = await _context.userDTO.FindAsync(id);
            if (userDTO != null)
            {
                _context.userDTO.Remove(userDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool userDTOExists(int id)
        {
          return (_context.userDTO?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
