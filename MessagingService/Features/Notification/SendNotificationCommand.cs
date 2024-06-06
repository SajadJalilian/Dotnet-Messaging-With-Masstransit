namespace MessagingService.Features.Notification;

record SendNotificationCommand(string Message, int UserId);