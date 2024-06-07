using FluentValidation;

namespace ApplicationService.Features.Notification;

class GetTaxRequestValidator : AbstractValidator<SendNotificationRequest>
{
    GetTaxRequestValidator()
    {
        RuleFor(x => x.Message)
            .NotEmpty()
            .WithMessage("Message is required");

        RuleFor(x => x.UserId)
            .NotNull()
            .WithMessage("User ID is required");
    }
}