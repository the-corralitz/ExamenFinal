using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenFinal.Models
{
    public class Respuestas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string Contenido { get; set; }
        public Guid PreguntaId { get; set; }
        [ForeignKey("PreguntaId")]
        public Respuestas Respuesta { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
