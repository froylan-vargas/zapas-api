using Zapas.Data.Models;

namespace zapas.Tests.Data.DbTestInitData
{
    public static class PlaceTestData
    {
        public static readonly Guid Place1Id = new Guid("e3fc39d7-c6ea-494a-91a5-c7ec95820190");
        public static List<Place> PlaceData
        {
            get { return CreateData(); }
        }

        private static List<Place> CreateData()
        {
            var place1 = new Place
            {
                Id = Place1Id,
                Name = "Viveros de Coyoacan"
            };
            return new() { place1 };
        }
    }
}
