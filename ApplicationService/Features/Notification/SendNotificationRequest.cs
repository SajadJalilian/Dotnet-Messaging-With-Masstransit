namespace ApplicationService.Features.Notification;

record SendNotificationRequest(string Message, int UserId, NotificationType[] NotificationTypes);