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
            var animal = _dbContext.Animals.Find(id);
            if(animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        /// <summary>
        /// Obtener todas las entidades(usando paginación del lado del servidor)
        /// </summary>
        [HttpGet]
        public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int pageSaze =10)
        {
            //calcular el indice
            int skip = (page -1) * pageSaze;

            var animalsPage = _dbContext.Animals
            .OrderBy(a => a.Id)
            .Skip(skip)
            .Take(pageSaze)
            .ToList();

            if (animalsPage.Any())
            {
                return Ok(animalsPage);
            }
            else
            {
                return NotFound("No se encontraron animales.");
            }
        }

        /// <summary>
        ///Crear una entidad nueva
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] Animal animal)
        {
            ValidationResult validationResult = _animalService.ValidateAnimal(animal);
            if (!validationResult.IsValid)
            {
                //Resultado invalido
                return BadRequest(validationResult.Errors);
            }

            try
            {
                _dbContext.Animals.Add(animal);
                _dbContext.SaveChanges();
                return Ok(animal);
            }
            catch(Exception ex)
            {
                //Error 500 base de datos no disponible
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
            
        }
        /// <summary>
        ///Editar una entidad existente
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Animal animal) 
        {
            try
            {
                var existingAnimal = _dbContext.Animals.Find(id);
                if(existingAnimal == null)
                {
                    return NotFound($"No se encontro ningun animal con el ID {id}");
                }

                ValidationResult validationResult = _animalService.ValidateAnimal(animal);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
                //actualizacion datos
                existingAnimal.Nombre = animal.Nombre;
                existingAnimal.FechaNacimiento = animal.FechaNacimiento;
                existingAnimal.Sexo = animal.Sexo;
                existingAnimal.Precio = animal.Precio;
                existingAnimal.Estado = animal.Estado;
                existingAnimal.Comentarios = animal.Comentarios;
                existingAnimal.Raza = animal.Raza;

                _dbContext.SaveChanges();

                return Ok(existingAnimal);
            } catch (Exception ex) 
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
                var animal = _dbContext.Animals.Find(id);

                if(animal == null)
                {
                    return NotFound($"No se encontro ningun animal con el ID {id}");
                }
                _dbContext.Animals.Remove(animal);

                _dbContext.SaveChanges();

                return Ok("Animal eliminado exitosamente");
            } catch(Exception ex)
            {
                //Error 500 base de datos no disponible
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtener un servicio que retorne el número de animales activos agrupados por su raza
        /// </summary>
        [HttpGet("active-count-by-raze")]
        public IActionResult GetActiveAnimalsCountByRaze()
        {
            try
            {
                var activeAnimalsByRaze = _animalService.GetActiveAnimalsCountByRace();
                return Ok(activeAnimalsByRaze);
            } catch(Exception ex )
            {
                //Error 500 base de datos no disponible
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
