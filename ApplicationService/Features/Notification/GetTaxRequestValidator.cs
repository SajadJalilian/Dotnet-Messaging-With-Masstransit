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

        RuleFor(x => x.NotificationTypes)
            .Must(x => x.Length > 0)
            .WithMessage("At least one type is required is required");
        
        RuleForEach(x => x.NotificationTypes)
            .IsInEnum()
            .WithMessage("Invalid notification type");
    }
}