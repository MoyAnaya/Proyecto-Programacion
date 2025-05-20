using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiestas.Data
{
    public class Reserva
    {
        public int Id { get; set; }
         
        [Required(ErrorMessage = "Campo obligatorio")]
        [DataType(DataType.Date)]
        public DateTime? fecha { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public virtual Clientes? Cliente { get; set; }

        [ForeignKey("Salon")]
        public int SalonId { get; set; }
        public virtual Salones? Salon { get; set; }
    }
}
