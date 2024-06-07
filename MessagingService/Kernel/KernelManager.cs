using MessagingService.Kernel.Inbox;

namespace MessagingService.Kernel;

internal static class KernelManager
{
    internal static IServiceCollection ConfigureKernel(this IServiceCollection services)
    {
        services.AddScoped<InboxService>();
        services.AddSingleton(TimeProvider.System);

        return services;
    }
}