using FluentValidation;
using ITQJ.Domain.DTOs;
using System;

namespace ITQJ.Domain.Validations
{
    public class ProfesionalSkillCreateDTOValidation : AbstractValidator<ProfesionalSkillCreateDTO>
    {
        public ProfesionalSkillCreateDTOValidation()
        {
            RuleFor(profesionalSkill => profesionalSkill.PersonalInfoId).NotEqual(Guid.Empty)
                .WithMessage($"El {nameof(LegalDocumentCreateDTO.DocumentTypeId)} no puede estar vacio.");

            RuleFor(profesionalSkill => profesionalSkill.SkillId).NotEqual(Guid.Empty)
                .WithMessage($"El {nameof(PersonalInfoCreateDTO.Name)} no puede estar vacio.");

            RuleFor(profesionalSkill => profesionalSkill.Percentage).NotEqual(0)
                .WithMessage($"El {nameof(PersonalInfoCreateDTO.PhoneNumber)} no puede estar vacio.");
        }
    }

    public class ProfesionalSkillUpdateDTOValidation : AbstractValidator<ProfesionalSkillUpdateDTO>
    {
        public ProfesionalSkillUpdateDTOValidation()
        {
            RuleFor(profesionalSkill => profesionalSkill.Percentage).NotNull()
                .WithMessage($"El {nameof(PersonalInfoCreateDTO.PhoneNumber)} no puede estar vacio.");
        }
    }
}
