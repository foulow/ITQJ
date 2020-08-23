using FluentValidation;
using ITQJ.Domain.DTOs;
using System;

namespace ITQJ.Domain.Validations
{
    public class PostulantCreateDTOValidation : AbstractValidator<PostulantCreateDTO>
    {
        public PostulantCreateDTOValidation()
        {
            RuleFor(postulant => postulant.UserId).NotEqual(Guid.Empty)
                .WithMessage($"El {nameof(PostulantCreateDTO.UserId)} no puede estar vacio.");

            RuleFor(postulant => postulant.ProjectId).NotEqual(Guid.Empty)
                .WithMessage($"El {nameof(PostulantCreateDTO.ProjectId)} no puede estar vacio.");
        }
    }

    public class PostulantUpdateDTOValidation : AbstractValidator<PostulantUpdateDTO>
    {
        public PostulantUpdateDTOValidation()
        {
            RuleFor(postulant => postulant.IsSelected).NotNull()
                .WithMessage($"El {nameof(PostulantUpdateDTO.IsSelected)} no puede estar vacio.");

            RuleFor(postulant => postulant.HasWorkReview).NotNull()
                .WithMessage($"El {nameof(PostulantUpdateDTO.HasWorkReview)} no puede estar vacio.");

            RuleFor(postulant => postulant.HasProyectReview).NotNull()
                .WithMessage($"El {nameof(PostulantUpdateDTO.HasProyectReview)} no puede estar vacio.");
        }
    }
}
