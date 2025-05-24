using FilmsApi.Application.Dtos;
using FluentValidation;


namespace  FilmsApi.Application.Validators
{
    public class CreateOrUpdateDirectorDtoValidators : AbstractValidator<CreateOrUpdateDirectorDto>
    {
        public CreateOrUpdateDirectorDtoValidators()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
            RuleFor(x => x.BirthDate).NotEmpty();
            RuleFor(x => x.Star).GreaterThan((byte)0).LessThanOrEqualTo((byte)5);
        }
    }
}
