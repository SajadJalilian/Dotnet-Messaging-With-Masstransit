using StackExchange.Redis;

namespace Core.LockManager
{
    public class LockManager : ILockManager
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly string Prefix;

        public LockManager(ConfigurationOptions options, string instancePrefix)
        {
            if (string.IsNullOrWhiteSpace(instancePrefix))
                throw new ArgumentException("Invalid instance prefix. Provide a valid string as prefix");

            Prefix = $"{instancePrefix.Trim().Replace(" ", "")}";
            _connectionMultiplexer = ConnectionMultiplexer.Connect(options);
        }

        public async Task<bool> IsLockedAsync(string key)
        {
            var redisKey = new RedisKey($"{Prefix}-{key}");
            var value = await _connectionMultiplexer.GetDatabase().StringGetAsync(redisKey);

            return value.HasValue;
        }

        public async Task<bool> TryToLockAsync(string key, TimeSpan? duration = null)
        {
            var redisKey = new RedisKey($"{Prefix}-{key}");
            duration ??= new TimeSpan(0, 0, 10);

            var ttl = await _connectionMultiplexer.GetDatabase().KeyTimeToLiveAsync(redisKey);
            var value = await _connectionMultiplexer.GetDatabase()
                .StringGetSetAsync(redisKey, new RedisValue($"{Prefix}-{key}-operation-is-locked"));

            await _connectionMultiplexer.GetDatabase().KeyExpireAsync(redisKey, new TimeSpan(0, 0, 1));

            if (ttl.HasValue)
                await _connectionMultiplexer.GetDatabase().KeyExpireAsync(redisKey, ttl);

            if (value.HasValue) return true;

            await _connectionMultiplexer.GetDatabase().KeyExpireAsync(redisKey, duration);
            return false;
        }

        public bool TryToUnlock(string key)
        {
            var redisKey = new RedisKey($"{Prefix}-{key}");
            return _connectionMultiplexer.GetDatabase().KeyDelete(redisKey);
        }
    }
}