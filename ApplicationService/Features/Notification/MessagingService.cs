using MassTransit;
using ServiceContracts;

namespace ApplicationService.Features.Notification;

class MessagingService(IPublishEndpoint publishEndpoint)
{
    internal async Task<bool> SendNotification(SendNotificationCommand request, CancellationToken cToken)
    {
        await publishEndpoint.Publish(new SendMessageBusRequest
        {
            Content = request.Content,
            UserId = request.UserId,
        }, cToken);

        return true;
    }
}