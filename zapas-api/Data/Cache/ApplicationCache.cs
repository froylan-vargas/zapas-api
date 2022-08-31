using Microsoft.Extensions.Caching.Memory;

namespace Zapas.Data.Cache
{
    public class ApplicationCache<T> : IApplicationCache<T> where T : class
    {
        private MemoryCache _cache { get; set; }
        public ApplicationCache()
        {
            _cache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = 100
            });
        }
        public T Get(string cacheKey)
        {
            T cachedResult;
            _cache.TryGetValue(
              cacheKey,
              out cachedResult);
            return cachedResult;
        }

        public void Remove(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        public void Set(T toBeCached, string cacheKey)
        {
            var cacheEntryOptions =
              new MemoryCacheEntryOptions().SetSize(1);
            _cache.Set(
              cacheKey,
              toBeCached,
              cacheEntryOptions);
        }
    }
}
