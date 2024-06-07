using MassTransit;
using ServiceContracts;

namespace MessagingService.Kernel.Inbox;

class SendMessageRequestConsumer : IConsumer<SendMessageBusRequest>
{
    private readonly InboxService _inboxService;

    public SendMessageRequestConsumer(InboxService inboxService)
    {
        _inboxService = inboxService;
    }

    public async Task Consume(ConsumeContext<SendMessageBusRequest> context)
    {
        var message = context.Message;
        var messageId = context.MessageId ?? new Guid(); 
        
        var result = await
            _inboxService.SentNotification(new SendMessageCommand(message.Content,
                    message.UserId, messageId),
                context.CancellationToken);
        
        if (result) await context.RespondAsync("ok");
        await context.RespondAsync("failed");
    }
}