using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        List<Proyecto> ObtenerProyectos();

    }

    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<Proyecto> ObtenerProyectos()
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

    }
}
