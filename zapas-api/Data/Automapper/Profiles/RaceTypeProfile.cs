using AutoMapper;
using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.Models;

namespace Zapas.Data.Automapper.Profiles
{
    public class RaceTypeProfile : Profile
    {
        public RaceTypeProfile()
        {
            CreateMap<RaceType, RaceTypeSelection>();
        }
    }
}
