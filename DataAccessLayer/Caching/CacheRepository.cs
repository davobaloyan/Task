using DataAccessLayer.Contracts;
using Enyim.Caching;
using System.Threading.Tasks;

namespace DataAccessLayer.Caching
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IMemcachedClient memcachedClient;

        public CacheRepository(IMemcachedClient memcachedClient)
        {
            this.memcachedClient = memcachedClient;
        }

        public async Task<bool> SetAsync<T>(string key, T value)
        {
            try
            {
                return await memcachedClient.SetAsync(key, value, 60 * 60);
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<T> GetCacheAsync<T>(string key)
        {
            try
            {
                var item = await memcachedClient.GetAsync<T>(key);
                if (item.HasValue)
                    return item.Value;
                else
                    return default(T);
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }

        public async Task<bool> DeleteAsync(string key)
        {
            try
            {
                return await memcachedClient.RemoveAsync(key);
            }
            catch (System.Exception)
            {
                return false;
            }
        }


    }
}
