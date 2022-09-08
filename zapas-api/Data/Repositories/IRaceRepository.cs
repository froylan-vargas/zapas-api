using System.Linq.Expressions;
using Zapas.Data.DTO.Race;
using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.Models;
using Zapas.Data.QueryOptions;

namespace Zapas.Data.Repositories
{
    public interface IRaceRepository
    {
        Task<RaceApiResult> GetRaces(RaceQueryOptions options);
    }
}