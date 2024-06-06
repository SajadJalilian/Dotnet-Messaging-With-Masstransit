using MassTransit;
using ServiceContracts;

namespace MessagingService.Features.Notification;

class SendNotificationRequestConsumer : IConsumer<SendNotificationBusRequest>
{
    private readonly NotificationService _notificationService;

    SendNotificationRequestConsumer(NotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task Consume(ConsumeContext<SendNotificationBusRequest> context)
    {
        var message = context.Message;
        var result = await
            _notificationService.SentNotification(new SendNotificationCommand(message.Message, message.Userid),
                context.CancellationToken);
        
        if (result) await context.RespondAsync("ok");
        await context.RespondAsync("failed");
    }
}