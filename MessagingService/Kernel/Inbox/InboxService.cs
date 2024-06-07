using MessagingService.Common.Data;

namespace MessagingService.Kernel.Inbox;

class InboxService(ApplicationDbContext dbContext, TimeProvider timeProvider)
{
    internal async Task<bool> SentNotification(SendMessageCommand command, CancellationToken cToken)
    {
        var messages = dbContext.Set<InboxMessage>();
        await messages.AddAsync(new InboxMessage
        {
            Content = command.Content,
            MessageId = command.MessageId,
            MessageType = MessageType.Full,
            CreatedOn = timeProvider.GetUtcNow().DateTime,
        }, cToken);

        var r = await dbContext.SaveChangesAsync(cToken);
        return r > 0;
    }
}