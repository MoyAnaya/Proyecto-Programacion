using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Fiestas.Data
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo Nombre no debe ser mayor a 50")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El campo telefono no debe exceder a mas de 10 digitos")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El campo Correo no es un correo valido")]
        [StringLength(100, ErrorMessage = "El campo Correo no debe ser mayor a 100")]
        public string? Correo { get; set; }

    }
}
