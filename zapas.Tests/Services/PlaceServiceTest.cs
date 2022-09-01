using Moq;
using Zapas.Data.Cache;
using Zapas.Data.Models;
using zapas.Tests.TestDB;
using Zapas.Services.PlaceService;
using FluentAssertions;

namespace zapas.Tests.Services
{
    public class PlaceServiceTest
    {
        private readonly Mock<IApplicationCache<IEnumerable<Place>>> _cache;
        public PlaceServiceTest()
        {
            _cache = new Mock<IApplicationCache<IEnumerable<Place>>>();
            _cache.Setup(c => c.Get(It.IsAny<string>())).Returns<Place>(null);
        }

        [Fact]
        public async void Should_Return_User_Zapas()
        {
            var _context = ApplicationTestDbContext.GetTestContext();
            var placeService = new PlaceService(_context, _cache.Object);
            var result = await placeService.Get();
            result.Count().Should().Be(1);
        }
    }
}
