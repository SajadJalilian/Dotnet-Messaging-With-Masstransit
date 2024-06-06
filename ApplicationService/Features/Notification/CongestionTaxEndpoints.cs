using DidarMessagingTask.Common.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DidarMessagingTask.Features.Notification;

static class CongestionTaxEndpoints
{
    internal static IEndpointRouteBuilder NotificationEndpoint(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapPost("/",
            async ([FromBody] SendNotificationRequest request, MessagingService service,
                CancellationToken cancellationToken) =>
            {
                var tax = await service.SendNotification(new SendNotificationRequest(request.Message, request.UserId),
                    cancellationToken);
                return Results.Ok(tax);
            }).Validator<SendNotificationRequest>();

        return endpoint;
    }
}