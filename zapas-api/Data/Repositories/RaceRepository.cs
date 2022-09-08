using System;
using System.Linq.Expressions;
using System.Numerics;
using System.Security.AccessControl;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zapas.Data.Automapper.Mappings;
using Zapas.Data.DTO.Race;
using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.Models;
using Zapas.Data.QueryFilters;
using Zapas.Data.QueryOptions;
using Zapas.Helpers;

namespace Zapas.Data.Repositories
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RaceRepository(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RaceApiResult> GetRaces(RaceQueryOptions options)
        {
            IQueryable<Race> query = _context.Set<Race>();
            var filters = RaceFilter.CreateGetRaceFilter(options);
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

            if(count > 0)
            {
                var includeProps = "Zapa,Place,RaceType";

                foreach (var includeProperty in includeProps.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }

                decimal totalDistance = query.Sum(r => r.Distance);
                int totalRacesPaceAvg = query.Sum(r => r.SpeedAvg) / count;
                var totalPaceAvg = DateHelper.RaceTimeToString(totalRacesPaceAvg);

                query = query.OrderByDescending(r => r.RaceStart)
                    .Skip(pageIndex!.Value * pageSize!.Value)
                    .Take(pageSize!.Value);

                var queryResult = await query.ToListAsync();

                IEnumerable<RaceDTO>? races = queryResult != null ?
                    DirectMapping<IEnumerable<RaceDTO>, IEnumerable<Race>>
                    .CreateMapping(_mapper, queryResult) :
                    null;

                raceResult = new RaceApiResult(races!,
                    count,
                    pageIndex!.Value,
                    pageSize!.Value,
                    totalDistance,
                    totalPaceAvg);
            }
            else
            {
                raceResult = new RaceApiResult(new List<RaceDTO>(), 0, 0, 0, 0, "");
            }
            return raceResult;
        }
    }
}

