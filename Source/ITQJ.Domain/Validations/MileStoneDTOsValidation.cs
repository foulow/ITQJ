using FluentValidation;
using ITQJ.Domain.DTOs;
using System;

namespace ITQJ.Domain.Validations
{
    public class MileStoneDTOsValidation : AbstractValidator<MileStoneCreateDTO>
    {
        public MileStoneDTOsValidation()
        {
            RuleFor(milestone => milestone.Description).NotNull().NotEmpty()
                .WithMessage($"El {nameof(MileStoneCreateDTO.Description)} no puede estar vacio.");

            RuleFor(milestone => milestone.FileName).NotNull().NotEmpty()
                .WithMessage($"El {nameof(MileStoneCreateDTO.FileName)} no puede estar vacio.");

            RuleFor(milestone => milestone.UploadDate).NotNull()
                .WithMessage($"El {nameof(MileStoneCreateDTO.UploadDate)} no puede estar vacio.");

            RuleFor(milestone => milestone.ProjectId).NotEqual(Guid.Empty)
                .WithMessage($"El {nameof(MileStoneCreateDTO.ProjectId)} no puede estar vacio.");

            RuleFor(milestone => milestone.UserId).NotEqual(Guid.Empty)
                .WithMessage($"El {nameof(MileStoneCreateDTO.UserId)} no puede estar vacio.");

        }
    }
}