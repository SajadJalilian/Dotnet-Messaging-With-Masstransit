using Core;
using MessagingService.Kernel.Inbox;

namespace MessagingService.Kernel;

internal static class KernelManager
{
    internal static IServiceCollection ConfigureKernel(this IServiceCollection services)
    {
        services.AddScoped<InboxService>();
        services.AddSingleton<ICustomTimeProvider, CustomTimeProvider>();
        services.AddHostedService<InboxMessageWorker>();

        return services;
    }
}