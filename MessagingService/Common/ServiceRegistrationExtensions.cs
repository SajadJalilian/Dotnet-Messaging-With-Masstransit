using MessagingService.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace MessagingService.Common;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection ConfigureDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(x =>
            x.UseNpgsql(configuration.GetConnectionString(MessagingConstants.DefaultConnection)));
        return services;
    }
}