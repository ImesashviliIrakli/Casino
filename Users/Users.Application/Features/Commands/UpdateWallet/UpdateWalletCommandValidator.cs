using FluentValidation;

namespace Users.Application.Features.Commands.UpdateWallet;

public class UpdateWalletCommandValidator : AbstractValidator<UpdateWalletCommand>
{
    public UpdateWalletCommandValidator()
    {
        RuleFor(command => command.transactionType)
            .NotEmpty().WithMessage("TransactionType is required.");

        RuleFor(command => command.playerUserId)
            .NotEmpty().WithMessage("PlayerUserId must not be empty.")
            .NotNull().WithMessage("PlayerUserId must not be null");

        RuleFor(command => command.amount)
            .NotNull().WithMessage("Amount must not be null.")
            .GreaterThanOrEqualTo(1).WithMessage("Amount can not be 0 or less");
    }
}
