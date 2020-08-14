using FluentValidation;
using ITQJ.Domain.DTOs;
using System;

namespace ITQJ.Domain.Validations
{
    public class ProjectCreateDTOValidation : AbstractValidator<ProjectCreateDTO>
    {
        public ProjectCreateDTOValidation()
        {
            RuleFor(project => project.UserId).NotEqual(Guid.Empty)
                .WithMessage($"El {nameof(ProjectCreateDTO.UserId)} no puede estar vacio.");

            RuleFor(project => project.Name).NotNull().NotEmpty()
                .WithMessage($"El {nameof(ProjectCreateDTO.Name)} no puede estar vacio.");

            RuleFor(project => project.PublishDate).NotNull()
                .WithMessage($"El {nameof(ProjectCreateDTO.PublishDate)} no puede estar vacio.");

            // Si el limite de postulante es cero, no tiene limites.
            //RuleFor(project => project.PostulantsLimit).NotEqual(0)
            //    .WithMessage($"El {nameof(ProjectCreateDTO.PostulantsLimit)} no puede estar vacio.");

            RuleFor(project => project.CloseDate).NotNull()
                .WithMessage($"El {nameof(ProjectCreateDTO.CloseDate)} no puede estar vacio.");

            RuleFor(project => project.IsOpen).NotNull().NotEqual(false)
                .WithMessage($"El {nameof(ProjectCreateDTO.IsOpen)} no puede estar vacio.");
        }
    }

    public class ProjectUpdateDTOValidation : AbstractValidator<ProjectUpdateDTO>
    {
        public ProjectUpdateDTOValidation()
        {
            // Si el limite de postulante es cero, no tiene limites.
            //RuleFor(project => project.PostulantsLimit).NotEqual(0)
            //    .WithMessage($"El {nameof(ProjectCreateDTO.PostulantsLimit)} no puede estar vacio.");

            RuleFor(project => project.CloseDate).NotNull()
                .WithMessage($"El {nameof(ProjectCreateDTO.CloseDate)} no puede estar vacio.");

            RuleFor(project => project.IsOpen).NotNull().NotEqual(false)
                .WithMessage($"El {nameof(ProjectCreateDTO.IsOpen)} no puede estar vacio.");
        }
    }
}
