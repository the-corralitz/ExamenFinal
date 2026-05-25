using ExamenFinal.Models.DTO;

namespace ExamenFinal.Interfaces
{
    public interface IRespuestasService
    {
        Task<bool> ResponderPregunta(Guid id, ResponderPreguntaDTO dto);
    }
}
