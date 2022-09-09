using System;

namespace Zapas.Data.DTO.Race
{
	public class RaceApiResult : BaseApiResult<Zapas.Data.Models.Race, RaceDTO>
	{
        public decimal? TotalDistance { get; private set; }
        public string? TotalPaceAvg { get; private set; }

        public RaceApiResult() { }

        public RaceApiResult(

            IEnumerable<RaceDTO>? raceResult,
			int count,
			int pageIndex,
			int pageSize,
            decimal totalDistance,
            string totalPaceAvg)
                : base(raceResult, count,pageIndex,pageSize,null,null)
		{
			TotalDistance = totalDistance;
			TotalPaceAvg = totalPaceAvg;
        } 
    }
}

