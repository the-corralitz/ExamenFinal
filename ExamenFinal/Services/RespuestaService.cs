using ExamenFinal.Interfaces;
using ExamenFinal.Models;
using ExamenFinal.Models.DTO;
using ExamenFinal.Persistence;

namespace ExamenFinal.Services
{
    public class RespuestaService : IRespuestasService
    {
        private readonly ApplicationDbContext _context;
        public RespuestaService(ApplicationDbContext context) 
        {
            context = _context;
        }

        public async Task<bool> ResponderPregunta(Guid id, ResponderPreguntaDTO dto)
        {
            var pregunta = await _context.Preguntas.FindAsync(id);
            if (pregunta == null)
                throw new Exception("No se encontró la pregunta.");

            var respuesta = new Respuestas
            {
                Contenido = dto.Contenido,
                PreguntaId = id
            };

            _context.Respuestas.Add(respuesta);
            await _context.SaveChangesAsync();

            var exito = await cambiarEstado(id);

            return exito;
        }

        private async Task<bool> cambiarEstado(Guid id)
        {
            var pregunta = await _context.Preguntas.FindAsync(id);
            pregunta.Estado = "Resuelta";
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
