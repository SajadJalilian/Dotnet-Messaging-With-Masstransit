namespace MessagingService.Kernel.Inbox;

record SendMessageCommand(string Content, int UserId, Guid MessageId);