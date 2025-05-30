using System.ComponentModel.DataAnnotations;

namespace Fiestas.Data
{
    public class Salones
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del salón es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del salón no puede exceder los 100 caracteres.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La capacidad del salón es obligatoria.")]
        [Range(1, 1000, ErrorMessage = "La capacidad del salón debe estar entre 1 y 1000.")]
        public int? Capacidad { get; set; }

        [Required(ErrorMessage = "La ubicación del salón es obligatoria.")]
        [StringLength(200, ErrorMessage = "La ubicación del salón no puede exceder los 200 caracteres.")]
        public string? Ubicacion { get; set; }

        [Required(ErrorMessage = "El precio del salón es obligatorio.")]
        [Range(0, 10000, ErrorMessage = "El precio del salón debe estar entre 0 y 10000.")]
        public decimal? Precio { get; set; }
    }
}
