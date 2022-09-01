using FluentAssertions;
using Moq;
using zapas.Tests.Data.DbTestInitData;
using zapas.Tests.TestDB;
using Zapas.Data.Cache;
using Zapas.Data.Models;
using Zapas.Services.ZapaService;

namespace zapas.Tests.Services
{
    public class ZapaServiceTest
    {
        private readonly Mock<IApplicationCache<IEnumerable<Zapa>>> _cache;
        public ZapaServiceTest()
        {
            _cache = new Mock<IApplicationCache<IEnumerable<Zapa>>>();
            _cache.Setup(c => c.Get(It.IsAny<string>())).Returns<Zapa>(null);
        }

        [Fact]
        public async void Should_Return_User_Zapas()
        {
            var _context = ApplicationTestDbContext.GetTestContext();
            var zapaService = new ZapaService(_context, _cache.Object);
            var result = await zapaService.GetByUserId(UserTestData.User1Id);
            result.Count().Should().Be(2);
        }
    }
}
