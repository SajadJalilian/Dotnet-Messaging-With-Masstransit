using MessagingService.Kernel.Inbox;
using ServiceContracts;

namespace MessagingService.Kernel;

internal static class KernelManager
{
    internal static IServiceCollection ConfigureKernel(this IServiceCollection services)
    {
        services.AddScoped<InboxService>();
        services.AddSingleton<ICustomTimeProvider, CustomTimeProvider>();

        return services;
    }
}