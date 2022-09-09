using System.Drawing.Printing;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zapas.Data.DTO;
using Zapas.Data.DTO.Race;
using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.Models;
using Zapas.Data.QueryFilters;
using Zapas.Data.QueryOptions;
using Zapas.Data.Repositories;
using Zapas.Helpers;
using System.Reflection;

namespace Zapas.Services.RaceService
{
    public class RaceService : IRaceService
    {
        private readonly BaseRepository<Race,RaceDTO> _repository;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RaceService(ApplicationDbContext context,
            IMapper mapper)
        {
            _repository = new BaseRepository<Race, RaceDTO>(context);
            _context = context;
            _mapper = mapper;
        }

        public async Task<RaceApiResult> QueryRaces(RaceQueryOptions options)
        {
            RaceHelper raceHelper = new();
            var baseApiResult = await _repository.Get(
                options,
                RaceFilter.CreateGetRaceFilter(options),
                raceHelper.GetRaceTotals)!;

            if (baseApiResult.Query == null) return new RaceApiResult();

            var data = await baseApiResult.Query!.Select(r => new RaceDTO() {
                Id = r.Id,
                RaceStart = r.RaceStart.ToShortDateString(),
                Distance = r.Distance,
                SpeedAvg = DateHelper.RaceTimeToString(r.SpeedAvg),
                Duration = DateHelper.RaceTimeToString(r.Duration),
                HRAvg = r.HRAvg,
                Description = r.Description,
                Comments = r.Comments,
                ZapaId = r.ZapaId,
                ZapaName = r.Zapa!.Name,
                PlaceId = r.PlaceId,
                PlaceName = r.Place!.Name,
                RaceTypeId = r.RaceTypeId,
                RaceTypeName = r.RaceType!.Name
            }).ToListAsync();

            List<string> extraFields = baseApiResult.ExtraFields!.ToList();

            RaceApiResult raceResult = new RaceApiResult(data,
                baseApiResult.TotalCount,
                baseApiResult.PageIndex,
                baseApiResult.PageSize,
                decimal.Parse(extraFields[0]),
                extraFields[1]); 
            
            return raceResult;
        }

        public async Task UpdateRace(Race race)
        {
            await _repository.Add(race);
        }
    }
}
