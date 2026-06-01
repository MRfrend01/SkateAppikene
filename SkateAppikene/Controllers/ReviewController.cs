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
            var username = HttpContext.Session.GetString("Kasutajanimi");

            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "Account");

            var reviews = _db.Reviews
                .Where(r => r.Kasutajanimi == username)
                .ToList();

            return View(reviews);
        }

   
        public IActionResult ParkReviews(string parkName)
        {
            if (string.IsNullOrEmpty(parkName))
                return RedirectToAction("MyReviews");

            var reviews = _db.Reviews
                .Where(r => r.ParkName == parkName)
                .OrderByDescending(r => r.Id)
                .ToList();

            ViewBag.ParkName = parkName;

            return View(reviews);
        }


        [HttpPost]
        public IActionResult AddReview(Review model)
        {
            var username = HttpContext.Session.GetString("Kasutajanimi");

            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "Account");

            model.Kasutajanimi = username;

            _db.Reviews.Add(model);
            model.ParkImage = "";
            _db.SaveChanges();
            

            return RedirectToAction("ParkReviews", new { parkName = model.ParkName });
        }


        public IActionResult Details(int id)
        {
            var username = HttpContext.Session.GetString("Kasutajanimi");

            var review = _db.Reviews.FirstOrDefault(
                r => r.Id == id &&
                     r.Kasutajanimi == username);

            if (review == null)
                return RedirectToAction("MyReviews");

            return View(review);
        }

      
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var username = HttpContext.Session.GetString("Kasutajanimi");

            var review = _db.Reviews.FirstOrDefault(
                r => r.Id == id &&
                     r.Kasutajanimi == username);

            return View(review);
        }


        [HttpPost]
        public IActionResult Edit(Review model)
        {
            var review = _db.Reviews.Find(model.Id);

            if (review == null)
                return RedirectToAction("MyReviews");

            review.Score = model.Score;
            review.Comment = model.Comment;

            //_db.SaveChanges();

            return RedirectToAction("Details", new { id = model.Id });
        }

        public IActionResult Delete(int id)
        {
            var username = HttpContext.Session.GetString("Kasutajanimi");

            var review = _db.Reviews.FirstOrDefault(
                r => r.Id == id &&
                     r.Kasutajanimi == username);

            if (review != null)
            {
                _db.Reviews.Remove(review);
                _db.SaveChanges();
            }

            return RedirectToAction("MyReviews");
        }
    }
}