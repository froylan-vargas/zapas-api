using Moq;
using zapas.Tests.TestDB;
using Zapas.Data.Cache;
using Zapas.Data.Models;
using Zapas.Services.RaceTypeService;
using FluentAssertions;

namespace zapas.Tests.Services
{
    public class RaceTypeServiceTest
    {
        private readonly Mock<IApplicationCache<IEnumerable<RaceType>>> _cache;

        public RaceTypeServiceTest()
        {
            _cache = new Mock<IApplicationCache<IEnumerable<RaceType>>>();
            _cache.Setup(c => c.Get(It.IsAny<string>())).Returns<RaceType>(null);
        }

        /*[Fact]
        public async void Should_Return_RaceTypes()
        {
            var _context = ApplicationTestDbContext.GetTestContext();
            var raceTypeService = new RaceTypeService(_context, _cache.Object);
            var result = await raceTypeService.Get();
            result.Should().NotBeNull();
        }*/
    }
}
