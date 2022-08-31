using Zapas.Data.Models;

namespace zapas.Tests.Data.DbTestInitData
{
    static class RaceTypeTestData
    {
        public static readonly Guid RaceType1Id = new Guid("de428ec8-58e1-4225-8cb0-15c4477ecdfd");
        public static readonly Guid RaceType2Id = new Guid("de428ec8-58e1-4225-8cb0-15c4477ecdff");
        public static List<RaceType> RaceTypeData
        {
            get { return CreateData(); }
        }

        private static List<RaceType> CreateData()
        {
            RaceType raceType1 = new()
            {
                Id = RaceType1Id,
                Name = "Distancia"
            };
            RaceType raceType2 = new()
            {
                Id = RaceType2Id,
                Name = "Recovery"
            };
            return new() { 
                raceType1,
                raceType2
            };
        }
    }
}
