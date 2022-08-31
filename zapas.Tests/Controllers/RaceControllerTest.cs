using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using zapas.Tests.Data.DbTestInitData;
using zapas.Tests.TestDB;
using Zapas.Controllers;
using Zapas.Data.DTO.Race;
using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.QueryFilters;
using Zapas.Services.PlaceService;
using Zapas.Services.RaceService;
using Zapas.Services.RaceTypeService;
using Zapas.Services.ZapaService;

namespace zapas.Tests.Controllers
{
    public sealed class RaceControllerTest
    {
        private readonly Mock<IRaceService> _raceService;
        private readonly Mock<IZapaService> _zapaService;
        private readonly Mock<IRaceTypeService> _raceTypeService;
        private readonly Mock<IPlaceService> _placeService;
        private readonly Fixture _fixture;
        private readonly RaceController _sut;

        private readonly Guid userId = UserTestData.User1Id;

        public RaceControllerTest() 
        {
            var mapper = MapperTestConfiguration.CreateMapper();
            _raceService = new Mock<IRaceService>();
            _zapaService = new Mock<IZapaService>();
            _raceTypeService = new Mock<IRaceTypeService>();
            _placeService = new Mock<IPlaceService>();
            _zapaService.Setup(zs => zs.GetByUserId(userId)).ReturnsAsync(ZapaTestData.ZapaData);
            _raceTypeService.Setup(rts => rts.Get()).ReturnsAsync(RaceTypeTestData.RaceTypeData);
            _placeService.Setup(ps => ps.Get()).ReturnsAsync(PlaceTestData.PlaceData);
            _fixture = new Fixture();
            _sut = new RaceController(
                _raceService.Object,
                _zapaService.Object,
                _raceTypeService.Object,
                _placeService.Object,
                mapper);
        }

        [Fact]
        public async void Should_Return_Races()
        {
            var raceOptions = _fixture.Create<GetRaceOptions>();
            var result = await _sut.GetRaces(raceOptions);
            result.Should().NotBeNull();
        }

        [Fact]
        public async void Should_Return_RaceOptions()
        {
            Guid userId = UserTestData.User1Id;
            var result = await _sut.GetRaceOptions(userId);
            var actual = result.Result != null ? 
                ((OkObjectResult)result.Result).Value as RaceOptions : 
                null;
            actual.Should().NotBeNull();
            actual!.PlaceSelection!.Count().Should().BeGreaterThan(0);
            actual!.ZapaSelection!.Count().Should().BeGreaterThan(0);
            actual!.RaceTypeSelection!.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public async void Should_Save_Race()
        {
            Guid user1Id = UserTestData.User1Id;
            var newRace = _fixture.Create<RaceDTO>();
            newRace.RaceStart = DateTime.Now.ToShortDateString();
            newRace.UserId = user1Id;
            var result = (OkResult) await _sut.AddRace(newRace);
            result.StatusCode.Should().Be(200);
            
        }
    }
}
