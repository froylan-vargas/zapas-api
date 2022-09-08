using System;
using Zapas.Data.Repositories;

namespace Zapas.Data.QueryOptions
{
	public class RaceQueryOptions : BaseQueryOptions
	{
        public string? UserId { get; set; }
        public Guid? ZapaId { get; set; }
        public Guid? RaceTypeId { get; set; }
        public Guid? PlaceId { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}

