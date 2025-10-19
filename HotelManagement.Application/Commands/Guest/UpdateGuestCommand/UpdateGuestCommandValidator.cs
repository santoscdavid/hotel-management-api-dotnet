using FluentValidation;
using HotelManagement.Application.Common.Validators;

namespace HotelManagement.Application.Commands.Guest.UpdateGuestCommand
{
    public sealed class UpdateGuestCommandValidator : AbstractValidator<UpdateGuestCommand>
    {
        public UpdateGuestCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("O nome do hóspede é obrigatório.").MinimumLength(7)
                .WithMessage("O nome deve ter pelo menos 7 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email do hóspede é obrigatório.")
                .EmailAddress().WithMessage("Formato de email inválido.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("O Telefone do hóspede é obrigatório.")
                .MinimumLength(8).WithMessage("O telefone deve ter pelo menos 8 caracteres.");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("O número do documento é obrigatório.")
                .MinimumLength(10).WithMessage("O número do documento é obrigatório");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .Must(ValidationHelpers.BeAtLeast18YearsOld)
                .WithMessage("O usuário deve ter no mínimo 18 anos.");
        }
    }
}