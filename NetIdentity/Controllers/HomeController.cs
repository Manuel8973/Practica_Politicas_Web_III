using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NetIdentity.Models;
using Microsoft.AspNetCore.Authorization;

namespace NetIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles = "Admin, Administrador")]
        //[Authorize(Policy = "MenoresEdad")]
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        // E políticas 
        [Authorize(Policy = "SoloMasculino")]
        public IActionResult SeccionMasculina()
        {
            ViewBag.Message = "Esta sección es solo para usuarios masculinos";
            return View("GenericMessage");
        }

        [Authorize(Policy = "SoloFemenino")]
        public IActionResult SeccionFemenina()
        {
            ViewBag.Message = "Esta sección es solo para usuarios femeninos";
            return View("GenericMessage");
        }

        [Authorize(Policy = "MasculinoOFemenino")]
        public IActionResult SeccionBinaria()
        {
            ViewBag.Message = "Esta sección es para usuarios con género binario (M/F)";
            return View("GenericMessage");
        }

        [Authorize(Policy = "ExcluyeMasculino")]
        public IActionResult SeccionNoMasculina()
        {
            ViewBag.Message = "Esta sección excluye a usuarios masculinos";
            return View("GenericMessage");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
