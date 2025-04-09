using Application.DTOs.Person;
using FluentValidation;

namespace Application.Validator
{
    public class PersonCreateValidator : AbstractValidator<PersonCreateDTO>
    {
        public PersonCreateValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Length(2, 50).WithMessage("First name must be between 2 and 50 characters.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters.");
            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .Must(date => date != default(DateTime)).WithMessage("Date of birth must be a valid date.")
                .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");
            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .IsInEnum()
                .WithMessage("Gender must be Male,Female,Other");
            RuleFor(x => x.BirthPlace)
                .NotEmpty().WithMessage("Birth place is required.")
                .Length(2, 100).WithMessage("Birth place must be between 2 and 100 characters.");
        }
    }
}
