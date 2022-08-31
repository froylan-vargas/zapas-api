using Zapas.Services.RaceService;
using zapas.Tests.TestDB;
using AutoFixture;
using Zapas.Data.Models;
using FluentAssertions;
using Zapas.Data.QueryFilters;
using zapas.Tests.Data;
using Zapas.Data.Repositories;
using Moq;

namespace zapas.Tests.Services
{
    public class RaceServiceTest
    {
        private readonly Fixture _fixture;
        private readonly Mock<IRaceRepository> _raceRepo;

        public RaceServiceTest()
        {
            _fixture = new Fixture();
            _raceRepo = new Mock<IRaceRepository>();
        }

        /*[Fact]
        public void Should_Return_Races()
        {
            var _context = ApplicationTestDbContext.GetTestContext();
            var raceService = new RaceService(_context,_raceRepo.Object);
            var options = GetRaceOptionsData.FilterDate();
            var result = raceService.QueryRaces(options);
            result.Should().NotBeNull();
        }*/

        /*[Fact]
        public async void Should_Create_Race()
        {
            var _context = ApplicationTestDbContext.GetTestContext();
            var beforeSaveCount = _context.Races.Count();
            var raceService = new RaceService(_context, _raceRepo.Object);
            var newRace = _fixture.Create<Race>();
            await raceService.UpdateRace(newRace);
            var afterSaveCount = _context.Races.Count();
            beforeSaveCount.Should().BeLessThan(afterSaveCount);
        }*/
    }
}
