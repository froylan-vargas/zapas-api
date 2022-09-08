using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Zapas.Data.Automapper.Mappings;
using Zapas.Data.DTO.Race;
using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.Models;
using Zapas.Data.QueryFilters;
using Zapas.Data.QueryOptions;
using Zapas.Services.PlaceService;
using Zapas.Services.RaceService;
using Zapas.Services.RaceTypeService;
using Zapas.Services.ZapaService;

namespace Zapas.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class RaceController : ControllerBase
    {
        private readonly IRaceService _raceService;
        private readonly IZapaService _zapaService;
        private readonly IRaceTypeService _raceTypeService;
        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;
        public RaceController(
            IRaceService raceService,
            IZapaService zapaService,
            IRaceTypeService raceTypeService,
            IPlaceService placeService,
            IMapper mapper)
        {
            _raceService = raceService;
            _zapaService = zapaService;
            _raceTypeService = raceTypeService;
            _placeService = placeService;
            _mapper = mapper;
        }

        // GET: api/races
        [HttpGet]
        public async Task<ActionResult<RaceApiResult>> GetRaces(
            [FromQuery] RaceQueryOptions options
            )
        {
            RaceApiResult races = await _raceService.QueryRaces(options);
            return Ok(races);
        }

        // Get: api/race/raceOptions/{userId}
        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<RaceOptions>> GetRaceOptions(string userId)
        {
            var zapas = await _zapaService.GetByUserId(userId);
            var raceTypes = await _raceTypeService.Get();
            var places = await _placeService.Get();
            var result = DoOptionsMapping(zapas, raceTypes, places);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddRace(RaceDTO raceDTO)
        {
            var race = DirectMapping<Race, RaceDTO>.CreateMapping(_mapper, raceDTO); 
            await _raceService.UpdateRace(race);
            return Ok();
        }

        private RaceOptions DoOptionsMapping(
            IEnumerable<Zapa> zapas,
            IEnumerable<RaceType> raceTypes,
            IEnumerable<Place> places)
        {
            return new()
            {
                ZapaSelection = DirectMapping<IEnumerable<ZapaSelection>, IEnumerable<Zapa>>.CreateMapping(_mapper, zapas),
                RaceTypeSelection = DirectMapping<IEnumerable<RaceTypeSelection>, IEnumerable<RaceType>>.CreateMapping(_mapper, raceTypes),
                PlaceSelection = DirectMapping<IEnumerable<PlaceSelection>, IEnumerable<Place>>.CreateMapping(_mapper, places),
            };
        }
    }
}