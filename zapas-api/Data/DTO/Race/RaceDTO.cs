using System;

namespace Zapas.Data.DTO.Race
{
    public class RaceDTO
    {
        public Guid Id { get; set; }
        public string? RaceStart { get; set; }
        public decimal Distance { get; set; }
        public string? SpeedAvg { get; set; }
        public string? Duration { get; set; }
        public int HRAvg { get; set; }
        public string? Description { get; set; }
        public string? Comments { get; set; }
        public Guid? ZapaId { get; set; }
        public string? ZapaName { get; set; }
        public Guid? RaceTypeId { get; set; }
        public string? RaceTypeName { get; set; }
        public string? UserId { get; set; }
        public Guid? PlaceId { get; set; }
        public string? PlaceName { get; set; }
    }
}

