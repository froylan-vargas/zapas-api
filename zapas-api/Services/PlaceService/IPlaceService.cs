using Zapas.Data.Models;

namespace Zapas.Services.PlaceService
{
    public interface IPlaceService
    {
        public Task<IEnumerable<Place>> Get();
    }
}
