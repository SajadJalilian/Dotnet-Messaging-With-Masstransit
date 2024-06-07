namespace MessagingService.Kernel.Inbox;

public record SendMessageCommand(string Content, int UserId, Guid MessageId);