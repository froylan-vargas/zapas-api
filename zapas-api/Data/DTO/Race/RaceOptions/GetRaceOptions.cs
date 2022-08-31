namespace Zapas.Data.DTO.Race.RaceOptions
{
    public class GetRaceOptions
    {
        public string? UserId { get; set; }
        public Guid? ZapaId { get; set; }
        public Guid? RaceTypeId { get; set; }
        public Guid? PlaceId { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
