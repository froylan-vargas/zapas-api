using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.Models;

namespace Zapas.Services.PlaceService
{
    public interface IPlaceService
    {
        public Task<IEnumerable<PlaceSelection>> GetSelection();
    }
}
