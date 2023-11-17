using Bovinos.Models;
using Bovinos.Services;
using Bovinos.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Bovinos.Controllers
{
    /// <summary>
    /// Controlador para las operaciones relacionadas con las razas de animales.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RaceController : Controller
    {
        private readonly IRaceService _raceService;
        private readonly RaceValidator _raceValidator;

        /// <summary>
        /// Constructor del controlador de razas.
        /// </summary>
        /// <param name="raceService">Servicio de razas.</param>
        /// <param name="raceValidator">Validador de razas.</param>
        public RaceController(IRaceService raceService, RaceValidator raceValidator)
        {
            _raceService = raceService ?? throw new ArgumentNullException(nameof(raceService));
            _raceValidator = raceValidator ?? throw new ArgumentNullException(nameof(raceValidator));
        }

        /// <summary>
        /// Obtener una entidad por identificador (Raza id)
        /// </summary>
        [HttpGet("{id}", Name = "GetRaceById")]
        public IActionResult Get(int id)
        {
            var race = _raceService.GetRaceById(id);

            if (race == null)
            {
                return NotFound();
            }

            return Ok(race);
        }

        /// <summary>
        /// Obtener todas las entidades Raza(usando paginación del lado del servidor)
        /// </summary>
        [HttpGet]
        public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var racesPage = _raceService.GetRaces(page, pageSize);

            if (racesPage.Any())
            {
                return Ok(racesPage);
            }
            else
            {
                return NotFound("No se encontraron razas.");
            }
        }

        /// <summary>
        /// Crear una entidad nueva (Raza)
        /// </summary>
        [HttpPost]
        public IActionResult Create(Race race)
        {
            try
            {
                _raceService.CreateRace(race);
                return Ok(race);
            }
            catch (Exception ex)
            {
                //Error 500 base de datos no disponible
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }

        /// <summary>
        /// Editar una entidad existente (Raza)
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Race race)
        {
            try
            {
                _raceService.UpdateRace(id, race);
                return Ok(race);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Eliminar un entidad existente
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _raceService.DeleteRace(id);
                return Ok("Raza eliminada exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }



        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
