using FilmsApi.Application.Dtos;
using FluentValidation;


namespace FilmsApi.Application.Validators
{
    public class CreateOrUpdateFilmDtoValidators : AbstractValidator<CreateOrUpdateFilmDto>
    {

        public CreateOrUpdateFilmDtoValidators()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Time).GreaterThan(0).LessThanOrEqualTo(50000);
            RuleFor(x => x.Star).GreaterThan((byte)0).GreaterThanOrEqualTo((byte)5);
        }

    }
}
