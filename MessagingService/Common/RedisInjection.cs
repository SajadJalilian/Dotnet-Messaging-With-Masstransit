using Core.LockManager.DependencyInjection;
using Core.LockManager.Models;

namespace MessagingService.Common;

public static class RedisInjection
{
    private const string RedisSectionKey = "Redis";
    private const string ServicePrefix = "sfk";
    public static void AddConfiguredRedis(this IServiceCollection services, IConfiguration configuration)
    {
        var redisConfig = configuration.GetSection(RedisSectionKey)
            .Get<RedisConfig>();
        services.AddLockManager(ServicePrefix, redisConfig);
    }
}