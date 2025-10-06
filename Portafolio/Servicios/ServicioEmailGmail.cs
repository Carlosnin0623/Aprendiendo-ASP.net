using System.Net;
using System.Net.Mail;
using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoViewModel contacto);
    }

    public class ServicioEmailGmail : IServicioEmail
    {
        private readonly IConfiguration configuration;

        public ServicioEmailGmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar(ContactoViewModel contacto)
        {
            var emailEmisor = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL")
                 ?? throw new ArgumentNullException("Email no configurado");

            var password = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD")
                          ?? throw new ArgumentNullException("Password no configurado");

            var host = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST")
                       ?? throw new ArgumentNullException("Host no configurado");

            var puerto = configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PUERTO");

            var smtpCliente = new SmtpClient(host, puerto);
            smtpCliente.EnableSsl = true;
            smtpCliente.UseDefaultCredentials = false;
            smtpCliente.Credentials = new NetworkCredential(emailEmisor, password);
            var mensaje = new MailMessage();
            mensaje.From = new MailAddress(emailEmisor, "Formulario de Contacto");
            mensaje.To.Add(emailEmisor); // te lo envías a ti mismo
            mensaje.Subject = $"EL cliente {contacto.Nombre} ({contacto.Email}) quiere contactarte";
            mensaje.Body = contacto.Mensaje;
            mensaje.IsBodyHtml = false;

            await smtpCliente.SendMailAsync(mensaje);


        }
    }
}
