using Zapas.Data.Cache;
using Zapas.Data.Models;

namespace Zapas.Services.RaceTypeService
{
    public class RaceTypeService : IRaceTypeService
    {
        private readonly Repository<RaceType> _raceTypeRepo;
        private readonly IApplicationCache<IEnumerable<RaceType>> _cache;
        
        public RaceTypeService(
            ApplicationDbContext context,
            IApplicationCache<IEnumerable<RaceType>> cache)
        {
            _raceTypeRepo = new Repository<RaceType>(context);
            _cache = cache;
        }
        public async Task<IEnumerable<RaceType>> Get()
        {
            IEnumerable<RaceType> cachedRaceTypes = _cache.Get(GetCacheKey());
            if (cachedRaceTypes != null)
            {
                return cachedRaceTypes;
            }
            else
            {
                var raceTypes = await _raceTypeRepo.Get();
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
