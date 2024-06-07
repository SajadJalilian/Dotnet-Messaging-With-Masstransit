using MassTransit;
using ServiceContracts;

namespace MessagingService.Kernel.Inbox;

class SendMessageRequestConsumer : IConsumer<SendMessageBusRequest>
{
    private readonly InboxService _inboxService;
    private readonly ILogger<SendMessageRequestConsumer> _logger;

    public SendMessageRequestConsumer(InboxService inboxService, ILogger<SendMessageRequestConsumer> logger)
    {
        _inboxService = inboxService;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<SendMessageBusRequest> context)
    {
        var message = context.Message;
        var messageId = context.MessageId ?? new Guid(); 
        
        var result = await
            _inboxService.SentNotification(new SendMessageCommand(message.Content,
                    message.UserId, messageId),
                context.CancellationToken);
        
        _logger.LogError($"id:{messageId}--content:{message.Content}");
        
        if (result) await context.RespondAsync("ok");
        await context.RespondAsync("failed");
    }
}