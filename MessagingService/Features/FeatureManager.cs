using MessagingService.Features.Notification;

namespace MessagingService.Features;

internal static class FeatureManager
{
    internal static IServiceCollection ConfigureNotificationFeature(this IServiceCollection services)
    {
        services.AddScoped<NotificationService>();

        return services;
    }
}