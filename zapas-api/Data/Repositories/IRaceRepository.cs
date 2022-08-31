using System.Linq.Expressions;
using Zapas.Data.DTO.Race;
using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.Models;

namespace Zapas.Data.Repositories
{
    public interface IRaceRepository
    {
        Task<RaceResult> GetRaces(GetRaceOptions options);
    }
}