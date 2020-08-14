using FluentValidation;
using ITQJ.Domain.DTOs;
using System;

namespace ITQJ.Domain.Validations
{
    public class PersonalInfoCreateDTOValidation : AbstractValidator<PersonalInfoCreateDTO>
    {
        public PersonalInfoCreateDTOValidation()
        {
            RuleFor(personalinfo => personalinfo.UserId).NotEqual(Guid.Empty)
                .WithMessage($"El {nameof(PersonalInfoCreateDTO.UserId)} no puede estar vacio.");

            RuleFor(personalinfo => personalinfo.Name).NotNull().NotEmpty()
                .WithMessage($"El {nameof(PersonalInfoCreateDTO.Name)} no puede estar vacio.");

            RuleFor(personalinfo => personalinfo.PhoneNumber).NotNull().NotEmpty()
                .WithMessage($"El {nameof(PersonalInfoCreateDTO.PhoneNumber)} no puede estar vacio.");

            RuleFor(personalinfo => personalinfo.Description).NotNull().NotEmpty()
                .WithMessage($"El {nameof(PersonalInfoCreateDTO.Description)} no puede estar vacio.");

            // La pagina de usuario puede ser nula.
            //RuleFor(personalinfo => personalinfo.PagLink).NotNull().NotEmpty()
            //    .WithMessage($"El {nameof(PersonalInfoCreateDTO.PagLink)} no puede estar vacio.");

            RuleFor(personalinfo => personalinfo.LegalDocumentId).NotEqual(Guid.Empty)
                .WithMessage($"El {nameof(PersonalInfoCreateDTO.LegalDocumentId)} no puede estar vacio.");
        }
    }

    public class PersonalInfoUpdateDTOValidation : AbstractValidator<PersonalInfoUpdateDTO>
    {
        public PersonalInfoUpdateDTOValidation()
        {
            RuleFor(personalinfo => personalinfo.Name).NotNull().NotEmpty()
                .WithMessage($"El {nameof(PersonalInfoUpdateDTO.Name)} no puede estar vacio.");

            RuleFor(personalinfo => personalinfo.PhoneNumber).NotNull().NotEmpty()
                .WithMessage($"El {nameof(PersonalInfoUpdateDTO.PhoneNumber)} no puede estar vacio.");

            RuleFor(personalinfo => personalinfo.Description).NotNull().NotEmpty()
                .WithMessage($"El {nameof(PersonalInfoUpdateDTO.Description)} no puede estar vacio.");

            // La pagina de usuario puede ser nula.
            //RuleFor(personalinfo => personalinfo.PagLink).NotNull().NotEmpty()
            //    .WithMessage($"El {nameof(PersonalInfoCreateDTO.PagLink)} no puede estar vacio.");
        }
    }
}
