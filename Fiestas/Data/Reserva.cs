using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Fiestas.Data
{
    public class Reserva : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Escoga fecha para el evento")]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public virtual Clientes? Cliente { get; set; }

        [ForeignKey("SalonId")]
        public int SalonId { get; set; }
        public virtual Salones? Salon { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var dbContext = validationContext.GetService(typeof(FiestasContext)) as FiestasContext;

            if (dbContext == null || fecha == null)
                yield break;

            bool conflicto = dbContext.Reservas.Any(r =>
                r.SalonId == this.SalonId &&
                r.fecha == this.fecha &&
                r.Id != this.Id);

            if (conflicto)
            {
                yield return new ValidationResult(
                    "Ya existe una reserva para este salón en esta fecha.",
                    new[] { nameof(fecha) });
            }
        }
    }
}
