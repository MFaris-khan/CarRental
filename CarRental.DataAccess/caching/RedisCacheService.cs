using System.Text.Json;
using CarRental.DataAccess.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace CarRental.DataAccess.Caching;

public class RedisCacheService : IRedisCacheService
{
    private readonly IDistributedCache _cache;

    public RedisCacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var data = await _cache.GetStringAsync(key);
        if (data == null) return default;
        return JsonSerializer.Deserialize<T>(data);
    }

    public async Task SetAsync<T>(string key, T data, TimeSpan expiry)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiry
        };
        var json = JsonSerializer.Serialize(data);
        await _cache.SetStringAsync(key, json, options);
    }

    public async Task RemoveAsync(string key)
    {
        await _cache.RemoveAsync(key);
    }
}