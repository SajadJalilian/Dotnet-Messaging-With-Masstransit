namespace ApplicationService.Features.Notification;

record SendNotificationCommand(string Message, int UserId, NotificationType[] NotificationTypes);