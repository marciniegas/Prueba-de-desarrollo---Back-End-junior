using Bovinos.Models;
using FluentValidation;

namespace Bovinos.Validators
{
    public class RaceValidator : AbstractValidator<Race>
    {
        public RaceValidator()
        {
            RuleFor(race => race).NotNull();
            RuleFor(race => race.Id).GreaterThan(0);
            RuleFor(race => race.Nombre).NotEmpty();
        }
    }
}
