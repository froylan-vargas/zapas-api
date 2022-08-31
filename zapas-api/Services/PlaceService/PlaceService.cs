using Zapas.Data.Cache;
using Zapas.Data.Models;

namespace Zapas.Services.PlaceService
{
    public class PlaceService : IPlaceService
    {
        private readonly Repository<Place> _placeRepo;
        private readonly IApplicationCache<IEnumerable<Place>> _cache;
        public PlaceService(
            ApplicationDbContext context,
            IApplicationCache<IEnumerable<Place>> cache) 
        {
            _placeRepo = new Repository<Place>(context);
            _cache = cache;
        }
        public async Task<IEnumerable<Place>> Get()
        {
            IEnumerable<Place> cachedPlaces = _cache.Get(GetCacheKey());
            if (cachedPlaces != null)
            {
                return cachedPlaces;
            }
            else
            {
                var places = await _placeRepo.Get();
                _cache.Set(places, GetCacheKey());
                return places;
            }
        }

        private string GetCacheKey()
        {
            return "places";
        }
    }
}
