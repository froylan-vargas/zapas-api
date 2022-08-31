using System;
namespace Zapas.Data.DTO.Race
{
	public class RaceResult
	{
        public IEnumerable<RaceDTO> RaceData { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalRaces { get; private set; }
        public decimal TotalDistance { get; private set; }
        public string TotalPaceAvg { get; private set; }
        public int TotalPages { get; private set; }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return ((PageIndex + 1) < TotalPages);
            }
        }

        public RaceResult(
			IEnumerable<RaceDTO> raceData,
			int count,
			int pageIndex,
			int pageSize,
			decimal totalDistance,
			string totalPaceAvg)
		{
			RaceData = raceData;
			PageIndex = pageIndex;
			PageSize = pageSize;
			TotalRaces = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
			TotalDistance = totalDistance;
			TotalPaceAvg = totalPaceAvg;
        }
    }
}

