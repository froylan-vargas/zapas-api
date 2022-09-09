using Zapas.Data.Models;
using Zapas.Data.Cache;
using Zapas.Data.DTO.Race.RaceOptions;
using Microsoft.EntityFrameworkCore;

namespace Zapas.Services.ZapaService
{
    public class ZapaService : IZapaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IApplicationCache<IEnumerable<ZapaSelection>> _cache;
        public ZapaService(ApplicationDbContext context,
            IApplicationCache<IEnumerable<ZapaSelection>> cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IEnumerable<ZapaSelection>>
            GetSelection(string userId)
        {
            IEnumerable<ZapaSelection> cachedZapas =
                _cache.Get(GetCacheKey(userId.ToString()));
            if (cachedZapas != null)
            {
                return cachedZapas;
            }
            else
            {
                var zapas = await _context.Zapas.AsNoTracking()
                    .Select(z=> new ZapaSelection()
                    {
                        Id = z.Id,
                        Name = z.Name
                    }).ToListAsync();

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
