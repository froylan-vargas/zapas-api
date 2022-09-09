using Microsoft.EntityFrameworkCore;
using Zapas.Data.Cache;
using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.Models;

namespace Zapas.Services.RaceTypeService
{
    public class RaceTypeService : IRaceTypeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IApplicationCache<IEnumerable<RaceTypeSelection>> _cache;
        
        public RaceTypeService(
            ApplicationDbContext context,
            IApplicationCache<IEnumerable<RaceTypeSelection>> cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IEnumerable<RaceTypeSelection>> GetSelection()
        {
            IEnumerable<RaceTypeSelection> cachedRaceTypes = _cache.Get(GetCacheKey());
            if (cachedRaceTypes != null)
            {
                return cachedRaceTypes;
            }
            else
            {
                var raceTypes = await _context.RaceTypes.AsNoTracking()
                    .Select(rt => new RaceTypeSelection()
                    {
                        Id = rt.Id,
                        Name = rt.Name
                    }).ToListAsync();

                _cache.Set(raceTypes, GetCacheKey());
                return raceTypes;
            }
        }

        private string GetCacheKey()
        {
            return "raceTypes";
        }
    }
}
