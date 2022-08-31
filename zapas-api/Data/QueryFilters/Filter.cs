using System.Composition;
using System.Linq.Expressions;
using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.Models;

namespace Zapas.Data.QueryFilters
{
    public class Filter
    {
        public static IEnumerable<Expression<Func<Race, bool>>> CreateFilter(GetRaceOptions options)
        {
            List<Expression<Func<Race, bool>>> predicates = new List<Expression<Func<Race, bool>>>();
            predicates.Add(CreateUserFilter(options));
            if(options.Year > 2020) predicates.Add(CreateDateFilter(options));
            if (options.PlaceId != null) predicates.Add(CreatePlaceFilter(options));
            if (options.RaceTypeId != null) predicates.Add(CreateRaceTypeFilter(options));
            if (options.ZapaId != null) predicates.Add(CreateZapaFilter(options));
            return predicates;
        }

        private static Expression<Func<Race,bool>> CreateUserFilter(GetRaceOptions options)
        {
            return r => r.UserId == options.UserId;
        }

        private static Expression<Func<Race, bool>> CreateDateFilter(GetRaceOptions options)
        {
            return r =>
                r.RaceStart.Year == options.Year
                    && r.RaceStart.Month == options.Month;
        }

        private static Expression<Func<Race, bool>> CreateZapaFilter(GetRaceOptions options)
        {
            return r =>
                r.ZapaId == options.ZapaId;
        }

        private static Expression<Func<Race, bool>> CreatePlaceFilter(GetRaceOptions options)
        {
            return r =>
                r.PlaceId == options.PlaceId;
        }
        private static Expression<Func<Race, bool>> CreateRaceTypeFilter(GetRaceOptions options)
        {
            return r =>
                r.RaceTypeId == options.RaceTypeId;
        }
    }
}
