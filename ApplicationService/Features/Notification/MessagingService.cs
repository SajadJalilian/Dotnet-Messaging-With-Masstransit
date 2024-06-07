using MassTransit;
using ServiceContracts;

namespace ApplicationService.Features.Notification;

class MessagingService
{
    private readonly ISendEndpointProvider _sendEndpointProvider;

    public MessagingService(ISendEndpointProvider sendEndpointProvider)
    {
        _sendEndpointProvider = sendEndpointProvider;
    }

    internal async Task<bool> SendNotification(SendNotificationCommand request, CancellationToken cToken)
    {
        var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri(NotificationConstants.ServiceAddressUri));
        await endpoint.Send(new SendMessageBusRequest
        {
            Content = request.Content,
            UserId = request.UserId,
        }, cToken);

        return true;
    }
}