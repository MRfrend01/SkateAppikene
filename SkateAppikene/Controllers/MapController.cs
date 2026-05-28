using Microsoft.AspNetCore.Mvc;
using SkateAppikene.Data;
using SkateAppikene.Models;

namespace SkateAppikene.Controllers
{
    public class MapController : Controller
    {
        private readonly AppDbContext _db;

        public MapController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var pins = _db.Pins.ToList();

            return View(pins);
        }

        [HttpPost]
        public IActionResult AddPin(
            double latitude,
            double longitude)
        {
            var user =
                HttpContext.Session.GetString(
                    "Kasutajanimi");

            if (string.IsNullOrEmpty(user))
            {
                return Unauthorized();
            }

            var pin = new Pin
            {
                Nimi = "New Skate Spot",
                Latitude = latitude,
                Longitude = longitude
            };

            _db.Pins.Add(pin);

            _db.SaveChanges();

            return Ok();
        }
    }
}