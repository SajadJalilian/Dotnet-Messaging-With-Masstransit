using ApplicationService.Common.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationService.Features.Notification;

static class CongestionTaxEndpoints
{
    internal static IEndpointRouteBuilder NotificationEndpoint(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapPost("/",
            async ([FromBody] SendNotificationRequest request, MessagingService service,
                CancellationToken cancellationToken) =>
            {
                var tax = await service.SendNotification(
                    new SendNotificationCommand(request.Message, request.UserId, request.NotificationTypes),
                    cancellationToken);
                return Results.Ok(tax);
            }).Validator<SendNotificationRequest>();

        return endpoint;
    }
}