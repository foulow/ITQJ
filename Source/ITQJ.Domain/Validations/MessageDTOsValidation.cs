using FluentValidation;
using ITQJ.Domain.DTOs;
using System;

namespace ITQJ.Domain.Validations
{
    public class MessageDTOsValidation : AbstractValidator<MessageCreateDTO>
    {
        public MessageDTOsValidation()
        {
            RuleFor(message => message.UserId).NotEqual(Guid.Empty)
                .WithMessage($"El {nameof(MessageCreateDTO.UserId)} no puede estar vacio.");

            RuleFor(message => message.ProjectId).NotEqual(Guid.Empty)
                .WithMessage($"El {nameof(MessageCreateDTO.ProjectId)} no puede estar vacio.");

            RuleFor(message => message.Text).NotNull().NotEmpty()
                .WithMessage($"El {nameof(MessageCreateDTO.Text)} no puede estar vacio.");
        }
    }
}
