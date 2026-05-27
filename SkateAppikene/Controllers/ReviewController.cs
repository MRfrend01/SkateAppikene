using Microsoft.AspNetCore.Mvc;
using SkateAppikene.Data;
using SkateAppikene.Models;

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


        // Ühe review detailid
        public IActionResult Details(int id)
        {
            var username =
                HttpContext.Session.GetString("Kasutajanimi");

            var review = _db.Reviews.FirstOrDefault(
                r => r.Id == id &&
                r.Kasutajanimi == username);

            if (review == null)
            {
                return RedirectToAction(
                    "MyReviews");
            }

            return View(review);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var username =
                HttpContext.Session.GetString("Kasutajanimi");

            var review = _db.Reviews.FirstOrDefault(
                r => r.Id == id &&
                r.Kasutajanimi == username);

            return View(review);
        }

        [HttpPost]
        public IActionResult Edit(Review model)
        {
            var review =
                _db.Reviews.Find(model.Id);

            review.Score = model.Score;

            _db.SaveChanges();

            return RedirectToAction(
                "Details",
                new { id = model.Id });
        }


        public IActionResult Delete(int id)
        {
            var username =
                HttpContext.Session.GetString("Kasutajanimi");

            var review = _db.Reviews.FirstOrDefault(
                r => r.Id == id &&
                r.Kasutajanimi == username);

            if (review != null)
            {
                _db.Reviews.Remove(review);

                _db.SaveChanges();
            }

            return RedirectToAction(
                "MyReviews");
        }

    }
}