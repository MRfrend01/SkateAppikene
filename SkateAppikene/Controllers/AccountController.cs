using Microsoft.AspNetCore.Mvc;
using SkateAppikene.Models;

namespace SkateAppikene.Controllers
{
    public class AccountController : Controller
    {
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

            // Siin saad kasutaja salvestada andmebaasi
            // Näiteks: _db.Users.Add(new User { ... });

            TempData["Teade"] = "Registreerimine õnnestus! Palun logi sisse.";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Siin käib autentimine
            // Näiteks: kontrollid parooli hash'i jne.

            return RedirectToAction("Index", "Home");
        }
    }
}
