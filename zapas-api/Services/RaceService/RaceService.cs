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
using System.Linq.Dynamic.Core;

namespace Zapas.Services.RaceService
{
    public class RaceService : IRaceService
    {
        //private readonly IRaceRepository _raceRepo;
        private readonly BaseRepository<Race> _repository;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RaceService(ApplicationDbContext context,
            IMapper mapper)
        {
            _repository = new BaseRepository<Race>(context);
            _context = context;
            _mapper = mapper;
        }

        public async Task<RaceApiResult> QueryRaces(RaceQueryOptions options)
        {
            var result = await _repository.Get(options,
                RaceFilter.CreateGetRaceFilter(options));
            var races = await result.Query.Select(r => new RaceDTO()
            {

            });

            /*(r => new RaceDTO()
            {
                Id = r.Id,
                RaceStart = r.RaceStart.ToShortDateString(),
                SpeedAvg = DateHelper.RaceTimeToString(r.SpeedAvg),
                Duration = DateHelper.RaceTimeToString(r.Duration),
                HRAvg = r.HRAvg,
                Description = r.Description,
                Comments = r.Comments,

            }).ToListAsync();*/

            var raceResult = new RaceApiResult(races,result.TotalCount,result.PageIndex.Value,result.PageSize.Value, 0,"");
            return raceResult!;
            /*IQueryable<Race> query = _context.Set<Race>();
            var filters = Filter.CreateFilter(options);
            var pageIndex = options.PageIndex;
            var pageSize = options.PageSize;

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            var count = await query.CountAsync();

            RaceApiResult? raceResult;

            if (count > 0)
            {
                var totalDistance = query.Sum(r => r.Distance);
                int totalRacesPaceAvg = query.Sum(r => r.SpeedAvg) / count;
                var totalPaceAvg = DateHelper.RaceTimeToString(totalRacesPaceAvg);

                var races = await query.Select(r => new RaceDTO()
                {
                    Id = r.Id,
                    RaceStart = r.RaceStart.ToShortDateString(),
                    SpeedAvg = DateHelper.RaceTimeToString(r.SpeedAvg),
                    Duration = DateHelper.RaceTimeToString(r.Duration),
                    HRAvg = r.HRAvg,
                    Description = r.Description,
                    Comments = r.Comments,

                }).ToListAsync();

                raceResult = new RaceApiResult(races,
                    count,
                    pageIndex,
                    pageSize,
                    totalDistance,
                    totalPaceAvg);
            }
            else
            {
                raceResult = new RaceApiResult(new List<RaceDTO>(), 0, 0, 0, 0, "");
            }
            return raceResult;*/
        }

        public async Task UpdateRace(Race race)
        {
            //await _repository.Add(race);
        }
    }
}
