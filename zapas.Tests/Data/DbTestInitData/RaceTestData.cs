using Zapas.Data.Models;

namespace zapas.Tests.Data.DbTestInitData
{
    public static class RaceTestData
    {

        private static readonly Guid Race1Id = new Guid("9041d0af-338a-4801-9620-a915459d6d50");
        public static List<Race> RaceData
        {
            get { return CreateData(); }
        }

        private static List<Race> CreateData()
        {
            var race1 = new Race
            {
                Id = Race1Id,
                RaceStart = new DateTime(2022,2,18),
                Distance = 21.1M,
                SpeedAvg = 120,
                Duration = 240,
                HRAvg = 90,
                ZapaId = ZapaTestData.zapa1Id,
                RaceTypeId = RaceTypeTestData.RaceType1Id,
                PlaceId = PlaceTestData.Place1Id,
                UserId = UserTestData.User1Id
            };
            var race2 = new Race
            {
                Id = Guid.NewGuid(),
                RaceStart = new DateTime(2022,3,26),
                Distance = 21.1M,
                SpeedAvg = 120,
                Duration = 240,
                HRAvg = 90,
                ZapaId = ZapaTestData.zapa2Id,
                RaceTypeId = RaceTypeTestData.RaceType1Id,
                PlaceId = PlaceTestData.Place1Id,
                UserId = UserTestData.User1Id
            };
            var race3 = new Race
            {
                Id = Guid.NewGuid(),
                RaceStart = new DateTime(2022, 3, 20),
                Distance = 42.2M,
                SpeedAvg = 120,
                Duration = 240,
                HRAvg = 125,
                ZapaId = ZapaTestData.zapa1Id,
                RaceTypeId = RaceTypeTestData.RaceType2Id,
                PlaceId = PlaceTestData.Place1Id,
                UserId = UserTestData.User1Id
            };
            return new() { 
                race1,
                race2,
                race3
            };
        }
    }
}
