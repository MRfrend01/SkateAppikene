using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SkateAppikene.Data;
using SkateAppikene.Models;

namespace SkateAppikene.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;

        public HomeController(
            ILogger<HomeController> logger,
            AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Map()
        {
            if (HttpContext.Session
                .GetString("Kasutajanimi") == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }

            var pins = _db.Pins.ToList();

            return View(pins);
        }

        [HttpPost]
        public IActionResult AddPin(
            string nimi,
            string tase,
            double latitude,
            double longitude)
        {
            var email =
                HttpContext.Session.GetString("Email");

            if (email != "admin@skateapp.ee")
            {
                return Unauthorized();
            }

            var pin = new Pin
            {
                Nimi = nimi,
                Tase = tase,
                Latitude = latitude,
                Longitude = longitude
            };
            if (pin != null)
            {             _db.Pins.Add(pin);
            _db.SaveChanges();
            }
   

            return Ok();
        }
        [HttpPost]
        public IActionResult DeletePin(int id)
        {
            var email =
                HttpContext.Session.GetString("Email");

            if (email != "admin@skateapp.ee")
            {
                return Unauthorized();
            }

            var pin = _db.Pins.Find(id);

            if (pin != null)
            {
                _db.Pins.Remove(pin);
                _db.SaveChanges();
            }

            return Ok();
        }

        public IActionResult Kasutajad()
        {
            var kasutajad = _db.Users.ToList();

            return View(kasutajad);
        }

        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId =
                    Activity.Current?.Id
                    ?? HttpContext.TraceIdentifier
            });
        }
    }
}