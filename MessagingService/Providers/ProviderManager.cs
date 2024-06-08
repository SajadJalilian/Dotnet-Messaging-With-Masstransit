using MessagingService.Providers.Email;
using MessagingService.Providers.Sms;

namespace MessagingService.Providers;

internal static class ProviderManager
{
    internal static IServiceCollection ConfigureProviders(this IServiceCollection services)
    {
        services.AddScoped<ISmsProvider, SmsProvider>();
        services.AddScoped<IEmailProvider, EmailProvider>();
        
        return services;
    }
}