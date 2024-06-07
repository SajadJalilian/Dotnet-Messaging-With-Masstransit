using MassTransit;
using ServiceContracts;

namespace MessagingService.Features.Inbox;

class SendNotificationRequestConsumer : IConsumer<SendNotificationBusRequest>
{
    private readonly InboxService _inboxService;

    SendNotificationRequestConsumer(InboxService inboxService)
    {
        _inboxService = inboxService;
    }

    public async Task Consume(ConsumeContext<SendNotificationBusRequest> context)
    {
        var message = context.Message;
        var result = await
            _inboxService.SentNotification(new SendMessageCommand(message.Message, message.UserId),
                context.CancellationToken);
        
        if (result) await context.RespondAsync("ok");
        await context.RespondAsync("failed");
    }
}