namespace ApplicationService.Features.Notification;

class MessagingService
{
    internal async Task<bool> SendNotification(SendNotificationCommand request, CancellationToken token)
    {
        return true;
    }
}