using DataAccessLayer.Contracts;

namespace BusinessLayer.Services
{
    abstract class BaseService
    {
        protected readonly ICacheRepository cacheRepository;

        public BaseService(ICacheRepository cacheRepository)
        {
            this.cacheRepository = cacheRepository;
        }
    }
}
