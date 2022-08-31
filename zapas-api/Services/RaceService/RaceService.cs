using System.Linq.Expressions;
using Zapas.Data.DTO.Race;
using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.Models;
using Zapas.Data.QueryFilters;
using Zapas.Data.Repositories;

namespace Zapas.Services.RaceService
{
    public class RaceService : IRaceService
    {
        private readonly IRaceRepository _raceRepo;
        private readonly Repository<Race> _repository;

        public RaceService(ApplicationDbContext applicationDbContext,
            IRaceRepository raceRepo)
        {
            _raceRepo = raceRepo;
            _repository = new Repository<Race>(applicationDbContext);
        }

        public async Task<RaceResult> QueryRaces(GetRaceOptions options)
        {
            return await _raceRepo.GetRaces(options);
        }

        public async Task UpdateRace(Race race)
        {
            await _repository.Add(race);
        }
    }
}
