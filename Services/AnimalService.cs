using Bovinos.Models;
using Bovinos.Validators;
using FluentValidation.Results;

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
            return _context.Animals.FirstOrDefault(a => a.Id == id);
        }

        Dictionary<string, int> IAnimalService.GetActiveAnimalsCountByRace()
        {
            var activeAnimalsByRace = _context.Animals
                .Where(a => a.Estado == "Activo")
                .AsEnumerable()
                .GroupBy(a => a.Raza)
                .ToDictionary(group => group.Key, group => group.Count());



            return activeAnimalsByRace;
        }
    }
}
