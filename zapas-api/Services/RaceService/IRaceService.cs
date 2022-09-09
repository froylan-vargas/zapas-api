using System.Linq.Expressions;
using Zapas.Data.DTO;
using Zapas.Data.DTO.Race;
using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.Models;
using Zapas.Data.QueryOptions;

namespace Zapas.Services.RaceService
{
    public interface IRaceService
    {
        Task<RaceApiResult> QueryRaces(RaceQueryOptions options);
        Task UpdateRace(Race race);
    }
}
