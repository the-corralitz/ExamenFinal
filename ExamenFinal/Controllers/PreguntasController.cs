using ExamenFinal.Interfaces;
using ExamenFinal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFinal.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class PreguntasController : Controller
    {
        private readonly IPreguntasService _preguntasService;
        public PreguntasController(IPreguntasService preguntasService)
        {
            _preguntasService = preguntasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearPreguntas([FromBody] PreguntasDTO[] preguntasDTO)
        {
            var created = await _preguntasService.CrearPreguntas(preguntasDTO);
            return Ok("Preguntas creadas");
        }

        [HttpGet("{estado}")]
        public async Task<IActionResult> FiltrarPreguntas(string estado)
        {
            return Ok(await _preguntasService.FiltrarPreguntas(estado));
        }
    }
}
