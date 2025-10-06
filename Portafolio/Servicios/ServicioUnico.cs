namespace Portafolio.Servicios
{
    public class ServicioUnico
    {
        // Crear el contructor 
        public ServicioUnico()
        {
            /* Un Guid es un string aleatorio largo, con esto esto instanciando
             * un nuevo string aleatorio */

            ObtenetGuid = Guid.NewGuid();
        }

        public Guid ObtenetGuid { get; private set; }
    }


    public class ServicioDelimitado
    {
        // Crear el contructor 
        public ServicioDelimitado()
        {
            /* Un Guid es un string aleatorio largo, con esto esto instanciando
             * un nuevo string aleatorio */

            ObtenetGuid = Guid.NewGuid();
        }

        public Guid ObtenetGuid { get; private set; }
    }


    public class ServicioTransitorio
    {
        // Crear el contructor 
        public ServicioTransitorio()
        {
            /* Un Guid es un string aleatorio largo, con esto esto instanciando
             * un nuevo string aleatorio */

            ObtenetGuid = Guid.NewGuid();
        }

        public Guid ObtenetGuid { get; private set; }
    }
}
