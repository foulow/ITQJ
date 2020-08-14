using FluentValidation;
using ITQJ.Domain.DTOs;
using System;

namespace ITQJ.Domain.Validations
{
    public class LegalDocumentCreateDTOValidation : AbstractValidator<LegalDocumentCreateDTO>
    {
        public LegalDocumentCreateDTOValidation()
        {
            RuleFor(legalDocument => legalDocument.DocumentTypeId).NotEqual(Guid.Empty)
                .WithMessage($"El {nameof(LegalDocumentCreateDTO.DocumentTypeId)} no puede estar vacio.");

            RuleFor(legalDocument => legalDocument.Number).NotNull().NotEmpty()
                .WithMessage($"El {nameof(PersonalInfoCreateDTO.Name)} no puede estar vacio.");

            RuleFor(legalDocument => legalDocument.Image).NotNull().NotEmpty()
                .WithMessage($"El {nameof(PersonalInfoCreateDTO.PhoneNumber)} no puede estar vacio.");
        }
    }

    public class LegalDocumentUpdateDTOValidation : AbstractValidator<LegalDocumentUpdateDTO>
    {
        public LegalDocumentUpdateDTOValidation()
        {
            RuleFor(legalDocument => legalDocument.Number).NotNull()
                .WithMessage($"El {nameof(PersonalInfoCreateDTO.Name)} no puede estar vacio.");

            RuleFor(legalDocument => legalDocument.Image).NotNull()
                .WithMessage($"El {nameof(PersonalInfoCreateDTO.PhoneNumber)} no puede estar vacio.");
        }
    }
}
