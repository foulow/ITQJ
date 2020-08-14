using FluentValidation;
using ITQJ.Domain.DTOs;

namespace ITQJ.Domain.Validations
{
    public class UserCreateDTOValidation : AbstractValidator<UserCreateDTO>
    {
        public UserCreateDTOValidation()
        {
            RuleFor(user => user.Email).NotNull().NotEmpty().EmailAddress()
                .WithMessage($"El {nameof(UserCreateDTO.Email)} no puede estar vacio.");

            RuleFor(user => user.Role).NotNull().NotEmpty()
                .WithMessage($"El {nameof(UserCreateDTO.Role)} no puede estar vacio.");
        }
    }
}
