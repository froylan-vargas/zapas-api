using System;
using Microsoft.EntityFrameworkCore;
using Zapas.Data.DTO;
using Zapas.Data.Models;

namespace Zapas.Helpers
{
    public delegate Task<IEnumerable<String>> ExtraQueryFields<T>(IQueryable<T> query, int count);

    public class RaceHelper
    {
        public async Task<IEnumerable<String>> GetRaceTotals(IQueryable<Race> query, int count)
        {
            var result = new List<string>();
            if(count>0)
            {
                var executedQuery = await query.ToListAsync();
                var aggregates = executedQuery.GroupBy(r => 1)
                    .Select(lg => new
                        {
                            TotalDistance = lg.Sum(r => r.Distance),
                            TotalSpeedAvg = lg.Sum(r => r.SpeedAvg) / count
                        }).FirstOrDefault();

                var totalSpeedAvg = DateHelper.
                    RaceTimeToString(aggregates!.TotalSpeedAvg);

                result.Add(aggregates!.TotalDistance.ToString());
                result.Add(totalSpeedAvg.ToString());
            }

            return result;
        }
    }
}

