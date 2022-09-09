using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.Models;

namespace Zapas.Services.RaceTypeService
{
    public interface IRaceTypeService
    {
        Task<IEnumerable<RaceTypeSelection>> GetSelection();
    }
}
