namespace Zapas.Data.Cache
{
    public interface IApplicationCache<T>
    {
        T Get(string cacheKey);
        void Remove(string cacheKey);
        void Set(T toBeCached, string cacheKey);
    }
}
