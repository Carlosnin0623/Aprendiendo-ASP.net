using ManejoPresupuesto.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class TipoCuenta //:  IValidatableObject // Validacion por modelo
    {
        public int Id { get; set; }

        // Validaciones al campo nombre del formulario con asp.net 
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        public int UsuarioId { get; set; }

        public int Orden {  get; set; }

        /* Pruebas de otras validaciones por defecto

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El campo {0} debe ser un correo electrónico válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 18, maximum:130, ErrorMessage = "El valor del campo {0} debe estar entre {2} y {1}")]
        public int Edad {  get; set; }

        [Url(ErrorMessage = "El campo {0} debe ser una URL válida")]
        public string URL { get; set; }

        [CreditCard(ErrorMessage = "La tarjeta de credito no es válida")]
        [Display(Name = "Tarjeta de Crédito")]
        public string TarjetaDeCredito { get; set; }

         */

        /* Esta validacion es a nivel de campo no a nivel de modelo esta para conocimiento 

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
           if(Nombre != null && Nombre.Length > 0)
            {
                var primeraLetra = Nombre.ToString()[0].ToString();

                if(primeraLetra != primeraLetra.ToUpper())
                {
                  // new[] { nameof(Nombre) Con esto le estamos diciendo que este error le corresponde al campo nombre 
                    yield return new ValidationResult("La primera letra debe ser mayúscula", new[] { nameof(Nombre) });
                }
            }
        }
        */
    }


}
