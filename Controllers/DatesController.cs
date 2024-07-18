﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cinema.data;

namespace cinema.Controllers
{
    public class DatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dates
        public async Task<IActionResult> Index()
        {
              return _context.Date != null ? 
                          View(await _context.Date.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Date'  is null.");
        }

        // GET: Dates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Date == null)
            {
                return NotFound();
            }

            var date = await _context.Date
                .FirstOrDefaultAsync(m => m.Id == id);
            if (date == null)
            {
                return NotFound();
            }

            return View(date);
        }

        // GET: Dates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,jour,mois,année")] Date date)
        {
            if (ModelState.IsValid)
            {
                _context.Add(date);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(date);
        }

        // GET: Dates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Date == null)
            {
                return NotFound();
            }

            var date = await _context.Date.FindAsync(id);
            if (date == null)
            {
                return NotFound();
            }
            return View(date);
        }

        // POST: Dates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,jour,mois,année")] Date date)
        {
            if (id != date.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(date);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DateExists(date.Id))
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
            return View(date);
        }

        // GET: Dates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Date == null)
            {
                return NotFound();
            }

            var date = await _context.Date
                .FirstOrDefaultAsync(m => m.Id == id);
            if (date == null)
            {
                return NotFound();
            }

            return View(date);
        }

        // POST: Dates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Date == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Date'  is null.");
            }
            var date = await _context.Date.FindAsync(id);
            if (date != null)
            {
                _context.Date.Remove(date);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DateExists(int id)
        {
          return (_context.Date?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
