namespace Zapas.Data.DTO.Race.RaceOptions
{
    public class RaceOptions
    {
        public IEnumerable<ZapaSelection>? ZapaSelection { get; set; }
        public IEnumerable<RaceTypeSelection>? RaceTypeSelection { get; set; }
        public IEnumerable<PlaceSelection>? PlaceSelection { get; set; }
    }
}

