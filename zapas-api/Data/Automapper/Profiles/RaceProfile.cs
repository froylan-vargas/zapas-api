using System;
using AutoMapper;
using Zapas.Data.Models;
using Zapas.Helpers;
using Zapas.Data.DTO.Race;

namespace Zapas.Data.Automapper.Profiles
{
	public class RaceProfile : Profile
	{
		public RaceProfile()
		{
			CreateMap<Race, RaceDTO>()
				.ForMember(dest => dest.RaceStart,
					opt => opt.MapFrom(src => src.RaceStart.ToShortDateString()))
				.ForMember(dest => dest.SpeedAvg,
					opt => opt.MapFrom(src => DateHelper.RaceTimeToString(src.SpeedAvg)))
				.ForMember(dest => dest.Duration,
					opt => opt.MapFrom(src => DateHelper.RaceTimeToString(src.Duration)))
				.ForMember(dest => dest.ZapaName,
					opt => opt.MapFrom(src => src.Zapa!.Name))
				.ForMember(dest => dest.RaceTypeName,
					opt => opt.MapFrom(src => src.RaceType!.Name))
				.ForMember(dest => dest.PlaceName,
					opt => opt.MapFrom(src => src.Place!.Name));

			CreateMap<RaceDTO, Race>()
				.ForMember(dest => dest.RaceStart,
					opt => opt.MapFrom(src => DateTime.Parse(src.RaceStart!)))
                .ForMember(dest => dest.SpeedAvg,
                    opt => opt.MapFrom(src => DateHelper.RaceTimeToSeconds(src.SpeedAvg!)))
                .ForMember(dest => dest.Duration,
                    opt => opt.MapFrom(src => DateHelper.RaceTimeToSeconds(src.Duration!)));
        }
	}
}

