using Microsoft.AspNetCore.Mvc;
using SkateAppikene.Data;

namespace SkateAppikene.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDbContext _db;

        public ReviewController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult MyReviews()
        {
            var username =
                HttpContext.Session.GetString("Kasutajanimi");

            // Kui pole sisse loginud
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }

            var reviews = _db.Reviews
                .Where(r => r.Kasutajanimi == username)
                .ToList();

            return View(reviews);
        }
    }
}