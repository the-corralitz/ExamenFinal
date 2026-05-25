using ExamenFinal.Interfaces;
using ExamenFinal.Models;
using ExamenFinal.Models.DTO;
using ExamenFinal.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExamenFinal.Services
{
    public class PreguntasService : IPreguntasService
    {
        private readonly ApplicationDbContext _context;
        public PreguntasService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Preguntas>>CrearPreguntas(PreguntasDTO[] dto)
        {
            var foo = new List<Preguntas>();

            foreach (PreguntasDTO preguntaDto in dto)
            {
                var pregunta = new Preguntas
                {
                    Categoria = preguntaDto.Categoria,
                    Enunciado = preguntaDto.Enunciado
                };

                _context.Preguntas.Add(pregunta);
                foo.Add(pregunta);
            }

            await _context.SaveChangesAsync();
            return foo;
        }

        public async Task<List<Preguntas>> FiltrarPreguntas(string estado)
        {
            var estados = new[] { "Sin resolver", "Resuelta" };
            if (!estados.Contains(estado))
                return await _context.Preguntas.ToListAsync();
            return await _context.Preguntas.Where(p => p.Estado == estado).ToListAsync();
        }
    }
}
