using System.Threading.Tasks;

namespace DataAccessLayer.Contracts
{
    public interface ICacheRepository
    {
        Task<bool> SetAsync<T>(string key, T value);
        Task<T> GetCacheAsync<T>(string key);
        Task<bool> DeleteAsync(string key);
    }
}
