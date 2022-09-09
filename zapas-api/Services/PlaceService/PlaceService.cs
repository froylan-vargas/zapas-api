using Zapas.Data.Cache;
using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Zapas.Services.PlaceService
{
    public class PlaceService : IPlaceService
    {
        private readonly IApplicationCache<IEnumerable<PlaceSelection>> _cache;
        private readonly ApplicationDbContext _context;

        public PlaceService(
            ApplicationDbContext context,
            IApplicationCache<IEnumerable<PlaceSelection>> cache) 
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IEnumerable<PlaceSelection>> GetSelection()
        {
            IEnumerable<PlaceSelection> cachedPlaces = _cache.Get(GetCacheKey());
            if (cachedPlaces != null)
            {
                return cachedPlaces;
            }
            else
            {
                var places = await _context.Places.AsNoTracking()
                    .Select(p=>new PlaceSelection()
                    {
                        Id = p.Id,
                        Name = p.Name
                    }).ToListAsync();

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
