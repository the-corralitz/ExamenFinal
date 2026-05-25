using ExamenFinal.Models;
using ExamenFinal.Models.DTO;

namespace ExamenFinal.Interfaces
{
    public interface IPreguntasService
    {
        Task<List<Preguntas>> CrearPreguntas(PreguntasDTO[] preguntas);
        Task<List<Preguntas>> FiltrarPreguntas(string estado);
    }
}
