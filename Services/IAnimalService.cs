using Bovinos.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Bovinos.Services
{
    public interface IAnimalService
    {
        
        ValidationResult ValidateAnimal(Animal animal);

        Animal GetAnimalById(int id);

        bool Update(int id,Animal animal);

        void Delete(int id);
        List<AnimalDto> GetAnimalPage(int page, int pageSize);

        void Create(Animal animal);

        IEnumerable<object> GetActiveAnimalsCountByRace();




    }
}
