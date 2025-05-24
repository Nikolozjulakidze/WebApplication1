using FilmsApi.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsApi.Application.Validators
{
    public class CreateOrUpdateUserDtoValidators : AbstractValidator<CreateOrUpdateUserDto>
    {
        public CreateOrUpdateUserDtoValidators()
        {
            RuleFor(u => u.Name).NotEmpty().MaximumLength(55);
            RuleFor(u => u.LastName).NotEmpty().MaximumLength(55);
            RuleFor(u => u.Email).NotEmpty().EmailAddress().WithMessage("Invalid Email Format");
            RuleFor(u => u.Role)
            .NotEmpty()
            .Must(role => new[] { "Admin", "Member", "User" }.Contains(role))
            .WithMessage("Role must be one of the following: Admin, Member, or User");

        }
    }
}
