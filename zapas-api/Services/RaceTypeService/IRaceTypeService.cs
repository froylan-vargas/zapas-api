using Zapas.Data.Models;

namespace Zapas.Services.RaceTypeService
{
    public interface IRaceTypeService
    {
        Task<IEnumerable<RaceType>> Get();
    }
}
