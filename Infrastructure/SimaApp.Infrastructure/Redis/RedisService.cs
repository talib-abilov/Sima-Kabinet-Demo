using Microsoft.EntityFrameworkCore.Storage;
using SimaApp.Application.Interfaces.Redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimaApp.Infrastructure.Redis
{
    public class RedisService : IRedisService
    {
        private readonly StackExchange.Redis.IDatabase _database;
        public RedisService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }


        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);

            if (value.IsNullOrEmpty)
                return default;

            return JsonSerializer.Deserialize<T>(value!);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
        {
            var json = JsonSerializer.Serialize(value);

            await _database.StringSetAsync(key,json, expiration);
        }
        public async Task DeleteAsync(string key)
        {
            await _database.KeyDeleteAsync(key);
        }
    }
}
