using zapas.Tests.Data.DbTestInitData;
using Zapas.Data.DTO.Race.RaceOptions;

namespace zapas.Tests.Data
{
    public class GetRaceOptionsData
    {
        public static GetRaceOptions FilterDate()
        {
            return new GetRaceOptions()
            {
                UserId = UserTestData.User1Id,
                Month = 3,
                Year = 2022,
                PageIndex = 0,
                PageSize = 20
            }; 
        }

        public static GetRaceOptions FilterRaceType()
        {
            return new GetRaceOptions()
            {
                UserId = UserTestData.User1Id,
                Month = 3,
                Year = 2022,
                RaceTypeId = RaceTypeTestData.RaceType1Id,
                PageIndex = 0,
                PageSize = 20
            };
        }

        public static GetRaceOptions FilterZapa()
        {
            return new GetRaceOptions()
            {
                UserId = UserTestData.User1Id,
                Month = 3,
                Year = 2022,
                ZapaId = ZapaTestData.zapa1Id,
                PageIndex = 0,
                PageSize = 20
            };
        }

        public static GetRaceOptions FilterPlace()
        {
            return new GetRaceOptions()
            {
                UserId = UserTestData.User1Id,
                Month = 3,
                Year = 2022,
                PlaceId = PlaceTestData.Place1Id,
                PageIndex = 0,
                PageSize = 20
            };
        }
    }
}
