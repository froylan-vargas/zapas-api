using Zapas.Data.Models;
using Zapas.Data.Cache;

namespace Zapas.Services.ZapaService
{
    public class ZapaService : IZapaService
    {
        private readonly Repository<Zapa> _zapaRepo;
        private readonly IApplicationCache<IEnumerable<Zapa>> _cache;
        public ZapaService(ApplicationDbContext context, IApplicationCache<IEnumerable<Zapa>> cache)
        {
            _zapaRepo = new Repository<Zapa>(context);
            _cache = cache;
        }
        public async Task<IEnumerable<Zapa>> GetByUserId(string userId)
        {
            IEnumerable<Zapa> cachedZapas = _cache.Get(GetCacheKey(userId.ToString()));
            if (cachedZapas != null)
            {
                return cachedZapas;
            }
            else
            {
                var zapas = await _zapaRepo.Get(z => z.UserId == userId);
                _cache.Set(zapas, GetCacheKey(userId.ToString()));
                return zapas;
            } 
        }

        private string GetCacheKey(string userId)
        {
            return $"zapa-user-{userId}";
        }
    }
}
