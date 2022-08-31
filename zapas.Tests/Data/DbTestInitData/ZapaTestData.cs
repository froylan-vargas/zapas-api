using Zapas.Data.Models;

namespace zapas.Tests.Data.DbTestInitData
{
    public static class ZapaTestData
    {
        public static readonly Guid zapa1Id = new("d95d6dd5-c307-4aa5-bb10-c43cf4517512");
        public static readonly Guid zapa2Id = new("d6ca3f10-c706-4c20-ab3f-8cdc76f54033");

        public static List<Zapa> ZapaData
        {
            get { return CreateData(); }
        }

        private static List<Zapa> CreateData()
        {
            Zapa zapa1 = new()
            {
                Id = zapa1Id,
                Brand = "Nike",
                Name = "Pegasus Turbo 2",
                Limit = 1000,
                InitialDate = DateTime.Now,
                EndDate = null,
                IsRetired = false,
                UserId = UserTestData.User1Id
            };

            Zapa zapa2 = new()
            {
                Id = zapa2Id,
                Brand = "Puma",
                Name = "Velocity Nitro 2",
                Limit = 1200,
                InitialDate = DateTime.Now,
                EndDate = null,
                IsRetired = false,
                UserId = UserTestData.User1Id
            };

            return new() { zapa1, zapa2 };
        }
    }
}
