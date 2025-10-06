using System.Diagnostics;
using Portafolio.Models;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Servicios;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /* RepositorioProyectos repositorioProyectos esta es una instancia que 
         * esta definida en el archivo Program.cs de la aplicación,
         * aqui se declaran las interfaces  */

        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly ServicioDelimitado servicioDelimitado;
        private readonly ServicioTransitorio servicioTransitorio;
        private readonly ServicioUnico servicioUnico;
        private readonly ServicioDelimitado servicioDelimitado2;
        private readonly ServicioTransitorio servicioTransitorio2;
        private readonly ServicioUnico servicioUnico2;
        private readonly IConfiguration configuration;
        private readonly IServicioEmail servicioEmailGmail;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos, ServicioDelimitado servicioDelimitado,
            ServicioTransitorio servicioTransitorio, ServicioUnico servicioUnico, 
            ServicioDelimitado servicioDelimitado2,
            ServicioTransitorio servicioTransitorio2,
            ServicioUnico servicioUnico2,
            IConfiguration configuration,
            IServicioEmail ServicioEmailGmail)

           // IConfiguration configuration con esto tenemos acceso a la informacion de los archivo de configuracion

        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioDelimitado = servicioDelimitado;
            this.servicioTransitorio = servicioTransitorio;
            this.servicioUnico = servicioUnico;
            this.servicioDelimitado2 = servicioDelimitado2;
            this.servicioTransitorio2 = servicioTransitorio2;
            this.servicioUnico2 = servicioUnico2;
            this.configuration = configuration;
            servicioEmailGmail = ServicioEmailGmail;
        }

        public IActionResult Index()
        {
            // IConfiguration: usando esta propiedad podemos obtener cualquier informacion

            var apellido = configuration.GetValue<string>("Apellido");
            _logger.LogTrace("Este es un mensaje de trace");
            _logger.LogDebug("Este es un mensaje de Debug");
            _logger.LogInformation("Este es un mensaje de Información");
            _logger.LogWarning("Este es un mensaje de Warning");
            _logger.LogError("Este es un mensaje de Error");
            _logger.LogCritical("Este es un mensaje de Critical " + apellido);
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();

            var guidViewModel = new EjemploGUIDViewModel()
            {
                Delimitado = servicioDelimitado.ObtenetGuid,
                Transitorio = servicioTransitorio.ObtenetGuid,
                Unico = servicioUnico.ObtenetGuid
            };

            var guidViewModel2 = new EjemploGUIDViewModel()
            {
                Delimitado = servicioDelimitado2.ObtenetGuid,
                Transitorio = servicioTransitorio2.ObtenetGuid,
                Unico = servicioUnico2.ObtenetGuid
            };

            var modelo = new HomeIndexViewModel() 
            {  Proyectos = proyectos,
               EjemploGUID_1 = guidViewModel,
               EjemploGUID_2 = guidViewModel2
            };

            return View(modelo);
        }

        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }


        [HttpGet]
        public IActionResult Contacto()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        // En este metodo es por donde se enviara la solicitud httpPost de la pagina de contacto
        [HttpPost] // Esto identifica una accion que suporta la solicitud http post
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            /*  Siempre que se envien datos desde un formulario se debe
             *  hacer una redireccion ya que por defecto cuando se actualiza
             la pagina donde esta un formulario aparece una ventana emergente
            de que si quiere volver a ejecutar la accion y eso puede hacer acciones
            duplicada, por eso es mejor redireccionar */
           await servicioEmailGmail.Enviar(contactoViewModel);
           return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
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
