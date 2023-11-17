using Bovinos.Models;
using Bovinos.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bovinos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly AnimalDbContext _dbContext;
        public AnimalController(IAnimalService animalService, AnimalDbContext animalDbContext)
        {
            _animalService = animalService;
            _dbContext = animalDbContext;
        }


        /// <summary>
        /// Obtiene un animal por su identificador.
        /// </summary>
        [HttpGet("{id}", Name = "GetAnimalById")]

        public IActionResult Get(int id)
        {
            var animal =_animalService.GetAnimalById(id);

            if (animal == null)
            {
                return NotFound();
            }
            var razaNombre = animal.Raza?.Nombre;

            return Ok(animal);
        }

        /// <summary>
        ///Editar una entidad existente
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Animal animal)
        {
            try
            {
                var updateResult = _animalService.Update(id, animal);

                if (!updateResult)
                {
                    return NotFound($"No se encontro ningun animal con el ID {id}");
                }


                return Ok(animal);
            }
            catch (Exception ex)
            {
                //Error 500 base de datos no disponible
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
                _animalService.Delete(id);
                return Ok("Animal eliminado exitosamente");

            }
            catch (Exception ex)
            {
                //Error 500 base de datos no disponible
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtener todas las entidades(usando paginación del lado del servidor)
        /// </summary>
        [HttpGet]
        public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int pageSaze =10)
        {
            try
            {
                var animalPage = _animalService.GetAnimalPage(page, pageSaze);
                if (animalPage.Any())
                {
                    return Ok(animalPage);
                }
                else
                {
                    return NotFound("No se encontraron animales.");
                }
            }catch(Exception ex) 
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

           
        }

        /// <summary>
        ///Crear una entidad nueva
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] Animal animal)
        {
                        
            try
            {
                _animalService.Create(animal);
                return Ok(animal);
            }
            catch(Exception ex)
            {
                //Error 500 base de datos no disponible
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
            
        }
        

        

        /// <summary>
        /// Obtener un servicio que retorne el número de animales activos agrupados por su raza
        /// </summary>
        [HttpGet("active-count-by-raze")]
        public IActionResult GetActiveAnimalsCountByRace()
        {
            try
            {
                var result = _animalService.GetActiveAnimalsCountByRace();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        /*public IActionResult Index()
        {
            return View();
        }
        */
    }
}
