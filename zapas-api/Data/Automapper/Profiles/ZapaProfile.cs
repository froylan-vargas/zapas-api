using AutoMapper;
using Zapas.Data.Models;
using Zapas.Data.DTO.Race.RaceOptions;

namespace Zapas.Data.Automapper.Profiles
{
    public class ZapaProfile : Profile
    {
        public ZapaProfile() 
        {
            CreateMap<Zapa, ZapaSelection>();
        }
    }
}
