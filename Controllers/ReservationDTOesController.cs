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
    public class ReservationDTOesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationDTOesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReservationDTOes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.reservationDTOs.Include(r => r.clientres).Include(r => r.planification);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReservationDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.reservationDTOs == null)
            {
                return NotFound();
            }

            var reservationDTO = await _context.reservationDTOs
                .Include(r => r.clientres)
                .Include(r => r.planification)
                .FirstOrDefaultAsync(m => m.idRéservation == id);
            if (reservationDTO == null)
            {
                return NotFound();
            }

            return View(reservationDTO);
        }

        // GET: ReservationDTOes/Create
        public IActionResult Create()
        {
            ViewData["clientID"] = new SelectList(_context.clients, "id", "id");
            ViewData["planificationID"] = new SelectList(_context.planifications, "id", "planinfo");
            return View();
        }

        // POST: ReservationDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idRéservation,clientID,planificationID")] ReservationDTO reservationDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservationDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["clientID"] = new SelectList(_context.clients, "id", "id", reservationDTO.clientID);
            ViewData["planificationID"] = new SelectList(_context.planifications, "id", "planinfo", reservationDTO.planificationID);
            TempData["SuccessMessage"] = "Vous avez fait une réservation avec succès";

            return View(reservationDTO);
        }

        // GET: ReservationDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.reservationDTOs == null)
            {
                return NotFound();
            }

            var reservationDTO = await _context.reservationDTOs.FindAsync(id);
            if (reservationDTO == null)
            {
                return NotFound();
            }
            ViewData["clientID"] = new SelectList(_context.clients, "id", "id", reservationDTO.clientID);
            ViewData["planificationID"] = new SelectList(_context.planifications, "id", "id", reservationDTO.planificationID);
            return View(reservationDTO);
        }

        // POST: ReservationDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idRéservation,clientID,planificationID")] ReservationDTO reservationDTO)
        {
            if (id != reservationDTO.idRéservation)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationDTOExists(reservationDTO.idRéservation))
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
            ViewData["clientID"] = new SelectList(_context.clients, "id", "Discriminator", reservationDTO.clientID);
            ViewData["planificationID"] = new SelectList(_context.planifications, "id", "planinfo", reservationDTO.planificationID);
            return View(reservationDTO);
        }

        // GET: ReservationDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.reservationDTOs == null)
            {
                return NotFound();
            }

            var reservationDTO = await _context.reservationDTOs
                .Include(r => r.clientres)
                .Include(r => r.planification)
                .FirstOrDefaultAsync(m => m.idRéservation == id);
            if (reservationDTO == null)
            {
                return NotFound();
            }

            return View(reservationDTO);
        }

        // POST: ReservationDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.reservationDTOs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.reservationDTOs'  is null.");
            }
            var reservationDTO = await _context.reservationDTOs.FindAsync(id);
            if (reservationDTO != null)
            {
                _context.reservationDTOs.Remove(reservationDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationDTOExists(int id)
        {
          return (_context.reservationDTOs?.Any(e => e.idRéservation == id)).GetValueOrDefault();
        }
    }
}
