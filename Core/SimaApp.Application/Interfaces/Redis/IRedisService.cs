using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Interfaces.Redis
{
    public interface IRedisService
    {
        Task SetAsync<T>(string key,T value,TimeSpan expiration);

        Task<T?> GetAsync<T>(string key);

        Task DeleteAsync(string key);
    }
}
