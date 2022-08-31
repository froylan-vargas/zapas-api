using AutoMapper;
using Zapas.Data.Automapper.Profiles;

namespace zapas.Tests.TestDB
{
    public class MapperTestConfiguration
    {
        public static IMapper CreateMapper()
        {
            List<Profile> profiles = new List<Profile>();
            AddProfiles(profiles);
            var config = new MapperConfiguration(cfg =>
                cfg.AddProfiles(profiles));
            return config.CreateMapper();
        }

        private static void AddProfiles(List<Profile> profiles)
        {
            profiles.Add(new ZapaProfile());
            profiles.Add(new RaceProfile());
            profiles.Add(new RaceTypeProfile());
            profiles.Add(new PlaceProfile());
        }
    }
}
