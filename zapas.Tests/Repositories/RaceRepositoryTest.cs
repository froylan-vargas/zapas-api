using System;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Options;
using zapas.Tests.Data;
using zapas.Tests.TestDB;
using Zapas.Data.Repositories;
using Zapas.Services.RaceService;

namespace zapas.Tests.Repositories
{
	public class RaceRepositoryTest
	{
        private readonly IMapper _mapper;

        public RaceRepositoryTest()
		{

            _mapper = MapperTestConfiguration.CreateMapper();
        }

        [Fact]
        public async void Should_Return_Race_By_Date()
        {
            var _context = ApplicationTestDbContext.GetTestContext();
            var raceRepository = new RaceRepository(_context,_mapper);
            var options = GetRaceOptionsData.FilterDate();
            var userRaces = await raceRepository.GetRaces(options);
            var userRace = userRaces.RaceData.First();
            var raceStart = DateTime.Parse(userRace!.RaceStart!);
            raceStart.Year.Should().Be(options.Year);
            raceStart.Month.Should().Be(options.Month);
        }

        [Fact]
        public async void Should_Return_Race_By_Place()
        {
            var _context = ApplicationTestDbContext.GetTestContext();
            var raceRepository = new RaceRepository(_context, _mapper);
            var options = GetRaceOptionsData.FilterPlace();
            var userRaces = await raceRepository.GetRaces(options);
            var userRace = userRaces.RaceData.First();
            userRace!.PlaceId.Should().Be(options.PlaceId);
        }

        [Fact]
        public async void Should_Return_Race_By_Zapa()
        {
            var _context = ApplicationTestDbContext.GetTestContext();
            var raceRepository = new RaceRepository(_context, _mapper);
            var options = GetRaceOptionsData.FilterZapa();
            var userRaces = await raceRepository.GetRaces(options);
            var userRace = userRaces.RaceData.First();
            userRace!.ZapaId.Should().Be(options.ZapaId!.Value);
        }

        [Fact]
        public async void Should_Return_Race_By_RaceType()
        {
            var _context = ApplicationTestDbContext.GetTestContext();
            var raceRepository = new RaceRepository(_context, _mapper);
            var options = GetRaceOptionsData.FilterRaceType();
            var userRaces = await raceRepository.GetRaces(options);
            var userRace = userRaces.RaceData.First();
            userRace!.RaceTypeId.Should().Be(options.RaceTypeId!.Value);
        }
    }
}

