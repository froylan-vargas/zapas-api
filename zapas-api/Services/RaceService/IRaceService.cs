using System.Linq.Expressions;
using Zapas.Data.DTO.Race;
using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.Models;

namespace Zapas.Services.RaceService
{
    public interface IRaceService
    {
        Task<RaceResult> QueryRaces(GetRaceOptions options);
        Task UpdateRace(Race race);
    }
}
