using MessagingService.Features.Email;
using MessagingService.Features.Sms;

namespace MessagingService.Features;

internal static class FeatureManager
{
    internal static IServiceCollection ConfigureFeatures(this IServiceCollection services)
    {
        services.AddScoped<ISmsProvider, SmsProvider>();
        services.AddScoped<IEmailProvider, EmailProvider>();
        
        return services;
    }
}