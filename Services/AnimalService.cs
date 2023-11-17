using Bovinos.Models;
using Bovinos.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bovinos.Services
{

    public class AnimalService : IAnimalService
    {
        private readonly AnimalValidator _animalValidator;
        private readonly AnimalDbContext _context;

        public AnimalService(AnimalValidator animalValidator, AnimalDbContext context)
        {
            _animalValidator = animalValidator;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        

        public ValidationResult ValidateAnimal(Animal animal)
        {
            return _animalValidator.Validate(animal);
        }

        public Animal GetAnimalById(int id)
        {
            return _context.Animals
            .Include(a => a.Raza)
            .FirstOrDefault(a => a.Id == id);
        }

        public bool Update(int id, Animal animal)
        {
            var existingAnimal = _context.Animals
                        .Include(a => a.Raza)
                        .FirstOrDefault(a => a.Id == id);
            if (existingAnimal == null)
            {
                return false; 
            }

            ValidationResult validationResult = ValidateAnimal(animal);

            if (!validationResult.IsValid)
            {
                return false;
            }

            // Actualiza los datos del animal existente.
            existingAnimal.Nombre = animal.Nombre;
            existingAnimal.FechaNacimiento = animal.FechaNacimiento;
            existingAnimal.Sexo = animal.Sexo;
            existingAnimal.Precio = animal.Precio;
            existingAnimal.Estado = animal.Estado;
            existingAnimal.Comentarios = animal.Comentarios;
            existingAnimal.RazaId = animal.RazaId;

            _context.SaveChanges();
            return true;
        }

        public void Delete(int id)
        {
            var animal = _context.Animals.Find(id);

            if (animal != null)
            {
                _context.Animals.Remove(animal);
                _context.SaveChanges();
            }
        }

        public List<AnimalDto> GetAnimalPage(int page, int pageSize)
        {
            //calcular el indice
            int skip = (page - 1) * pageSize;

            var animalsPage = _context.Animals
                .Include(a => a.Raza)
                .OrderBy(a => a.Id)
                .Skip(skip)
                .Take(pageSize)
                .Select(a => new AnimalDto
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    FechaNacimiento = a.FechaNacimiento,
                    Sexo = a.Sexo,
                    Precio = a.Precio,
                    Estado = a.Estado,
                    Comentarios = a.Comentarios,
                    RazaId = a.RazaId,
                    RazaNombre = a.Raza != null ? a.Raza.Nombre : null
                })
                .ToList();

               return animalsPage;
        }

        public void Create(Animal animal)
        {
            var existingRaza = _context.Razas.Find(animal.RazaId);
            if (existingRaza != null)
            {
                animal.Raza = existingRaza;
                _context.Animals.Add(animal);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException($"No se encontró ninguna Raza con el ID {animal.RazaId}");
            }
        }

        public IEnumerable<object> GetActiveAnimalsCountByRace()
        {
            var activeAnimalsByRace = _context.Animals
                .Where(a => a.Estado == "Activo" )
                .GroupBy(a => new { a.RazaId, a.Raza.Nombre })
                .Select(group => new
                {
                    group.Key.RazaId,
                    RazaNombre = group.Key.Nombre,
                    Count = group.Count()
                })
                .ToList();

            return activeAnimalsByRace.Select(item => new
            {
                item.RazaId,
                item.RazaNombre,
                item.Count
            });
        }


    }
}
