using Bovinos.Models;
using FluentValidation;

namespace Bovinos.Validators
{
    public class AnimalValidator : AbstractValidator<Animal>
    {
        public AnimalValidator()
        {
            RuleFor(a => a.Nombre).NotEmpty().WithMessage("El nombre del animal es obligatorio.");
            RuleFor(a => a.Precio).GreaterThan(0).WithMessage("El precio debe ser mayor que cero.");
        }
    }
}
