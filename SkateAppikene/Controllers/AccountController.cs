using Microsoft.AspNetCore.Mvc;
using SkateAppikene.Models;

namespace SkateAppikene.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // Salvesta kasutaja sessiooni (hiljem saad asendada andmebaasiga)
            HttpContext.Session.SetString("Kasutajanimi", model.Kasutajanimi);

            TempData["Teade"] = "Registreerimine õnnestus!";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // Siin käib päris autentimine — praegu lihtsalt email kasutajanimeks
            HttpContext.Session.SetString("Kasutajanimi", model.Email);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}