using FluentValidation;

namespace ApplicationService.Features.Notification;

public class SendNotificationRequestValidator : AbstractValidator<SendNotificationRequest>
{
    public SendNotificationRequestValidator()
    {
        RuleFor(x => x.Message)
            .NotEmpty()
            .WithMessage("Message is required");

        RuleFor(x => x.UserId)
            .NotNull()
            .WithMessage("User ID is required");
    }
}