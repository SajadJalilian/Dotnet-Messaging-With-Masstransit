using MessagingService.Features.Inbox;

namespace MessagingService.Features;

internal static class FeatureManager
{
    internal static IServiceCollection ConfigureNotificationFeature(this IServiceCollection services)
    {
        services.AddScoped<InboxService>();

        return services;
    }
}