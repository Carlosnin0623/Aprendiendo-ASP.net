using System.Diagnostics;
using _21_Proyecto_Portafolio_real.Models;
using Microsoft.AspNetCore.Mvc;

namespace _21_Proyecto_Portafolio_real.Controllers
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
            var proyectos = ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos};


            return View(modelo);
        }

        private List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>() {
                
                new Proyecto
            {
                Titulo = "Amazon",
                Descripcion = "E-Commerse realizado en ASP.NET Core",
                Link = "https://amazon.com",
                ImagenUrl = "/Imagenes/amazon.png"


            },

                new Proyecto
            {
                Titulo = "New York Times",
                Descripcion = "Paginas de noticias en React",
                Link = "https://nytimes.com",
                ImagenUrl = "/Imagenes/nyt.png"

            },

                new Proyecto
            {
                Titulo = "Reddit",
                Descripcion = "Red social para compartir en comunidades",
                Link = "https://reddit.com",
                ImagenUrl = "/Imagenes/reddit.png"

            },


                new Proyecto
            {
                Titulo = "Steam",
                Descripcion = "Tienda en linea para comprar videojuegos",
                Link = "https://store.steampowered.com",
                ImagenUrl = "/Imagenes/steam.png"

            },

            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
