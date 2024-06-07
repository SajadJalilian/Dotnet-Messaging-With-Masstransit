using ApplicationService.Common.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationService.Features.Notification;

static class NotificationEndpoints
{
    internal static IEndpointRouteBuilder NotificationEndpoint(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapPost("/",
            async ([FromBody] SendNotificationRequest request, MessagingService service,
                CancellationToken cancellationToken) =>
            {
                var tax = await service.SendNotification(
                    new SendNotificationCommand(request.Message, request.UserId),
                    cancellationToken);
                return Results.Ok(tax);
            }).Validator<SendNotificationRequest>();

        return endpoint;
    }
}