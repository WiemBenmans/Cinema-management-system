using cinema.Model;
using cinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
     
        public IActionResult RedirectToFilmDTO()
        {
            return RedirectToAction("Index", "FilmDTOes");
        }
        public IActionResult RedirectToclient()
        {
            return RedirectToAction("Index", "Clients");
        }
        public IActionResult RedirectTouserDTO()
        {
            return RedirectToAction("Index", "userDTOes");
        }
        public IActionResult RedirectTosalleDTO()
        {
            return RedirectToAction("Index", "salleDTOes");
        }
        public IActionResult RedirectTopositionDTO()
        {
            return RedirectToAction("Index", "positionDTOes");
        }
        public IActionResult RedirectToplanificationDTO()
        {
            return RedirectToAction("Index", "Planifications");
        }
        public IActionResult RedirectToReservation()
        {
            return RedirectToAction("Index", "ReservationDTOes");
        }
        public IActionResult RedirectTodate()
        {
            return RedirectToAction("Index", "Dates");
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}