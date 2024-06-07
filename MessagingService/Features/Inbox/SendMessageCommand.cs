namespace MessagingService.Features.Inbox;

record SendMessageCommand(string Message, int UserId);