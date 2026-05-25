using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenFinal.Models
{
    public class Preguntas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Enunciado { get; set; }
        public string Categoria { get; set; }
        public string Estado { get; set; } = "Sin resolver";
    }
}
