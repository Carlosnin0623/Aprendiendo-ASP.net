using System.Diagnostics;
using _20_Proyecto_Portafolio.Models;
using Microsoft.AspNetCore.Mvc;

namespace _20_Proyecto_Portafolio.Controllers
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
            
            /* Pasando datos a la vista usando un modelo fuertemente tipado */

            var persona = new Persona()
            {
                Nombre = "Carlos Alberto",
                Edad = 28,
                Sexo = "Hombre"
            };

            return View(persona);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            var persona = new Persona()
            {
                Nombre = "Carlos Alberto",
                Edad = 15,
                Sexo = "Hombre"
            };

            return View(persona);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
