using MassTransit;
using ServiceContracts;

namespace ApplicationService.Features.Notification;

class MessagingService(IBus bus)
{
    internal async Task<bool> SendNotification(SendNotificationCommand request, CancellationToken cToken)
    {
        var sendEndpoint = await bus.GetSendEndpoint(new Uri(MessagingEndpoints.ServiceUri));
        await sendEndpoint.Send(new SendMessageBusRequest
        {
            Content = request.Content,
            UserId = request.UserId,
        }, cToken);

        return true;
    }
}