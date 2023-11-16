using Bovinos.Models;
using FluentValidation.Results;

namespace Bovinos.Services
{
    public interface IAnimalService
    {
        
        ValidationResult ValidateAnimal(Animal animal);

        Animal GetAnimalById(int id);
        Dictionary<String, int> GetActiveAnimalsCountByRace();
        
    }
}
