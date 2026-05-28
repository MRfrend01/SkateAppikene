using Microsoft.AspNetCore.Mvc;
using SkateAppikene.Data;
using SkateAppikene.Models;

namespace SkateAppikene.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _db;

        public AccountController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (_db.Users.Any(u =>
                u.Email == model.Email))
            {
                ModelState.AddModelError(
                    "Email",
                    "See e-post on juba kasutusel");

                return View(model);
            }

            if (_db.Users.Any(u =>
                u.Kasutajanimi ==
                model.Kasutajanimi))
            {
                ModelState.AddModelError(
                    "Kasutajanimi",
                    "See kasutajanimi on juba võetud");

                return View(model);
            }

            var user = new User
            {
                Eesnimi = model.Eesnimi,
                Perenimi = model.Perenimi,
                Email = model.Email,
                Kasutajanimi = model.Kasutajanimi,

                ParoolHash =
                    BCrypt.Net.BCrypt
                    .HashPassword(model.Parool),

                // ainult see email saab admin
                Tase =
                    model.Email ==
                    "admin@skateapp.ee"
                    ? "Admin"
                    : "User"
            };

            _db.Users.Add(user);

            _db.SaveChanges();

            HttpContext.Session.SetString(
                "Kasutajanimi",
                user.Kasutajanimi);

            HttpContext.Session.SetString(
                "Email",
                user.Email);

            HttpContext.Session.SetString(
                "Tase",
                user.Tase);

            TempData["Teade"] =
                "Registreerimine õnnestus!";

            return RedirectToAction(
                "Index",
                "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(
            LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user =
                _db.Users.FirstOrDefault(
                u => u.Email == model.Email);

            if (user == null ||
                !BCrypt.Net.BCrypt.Verify(
                model.Parool,
                user.ParoolHash))
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Vale e-post või parool");

                return View(model);
            }

            HttpContext.Session.SetString(
                "Kasutajanimi",
                user.Kasutajanimi);

            HttpContext.Session.SetString(
                "Email",
                user.Email);

            HttpContext.Session.SetString(
                "Tase",
                user.Tase);

            return RedirectToAction(
                "Index",
                "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(
                "Index",
                "Home");
        }
    }
}