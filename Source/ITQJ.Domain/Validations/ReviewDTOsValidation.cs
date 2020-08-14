using FluentValidation;
using ITQJ.Domain.DTOs;
using System;

namespace ITQJ.Domain.Validations
{
    public class ReviewCreateDTOValidation : AbstractValidator<ReviewCreateDTO>
    {
        public ReviewCreateDTOValidation()
        {
            RuleFor(review => review.UserId).NotEqual(Guid.Empty)
                .WithMessage($"El {nameof(ReviewCreateDTO.UserId)} no puede estar vacio.");

            RuleFor(review => review.Points).NotNull().NotEqual(0)
                .WithMessage($"El {nameof(ReviewCreateDTO.Points)} no puede estar vacio.");

            RuleFor(review => review.Description).NotNull().NotEmpty()
                .WithMessage($"El {nameof(ReviewCreateDTO.Description)} no puede estar vacio.");
        }
    }
}
