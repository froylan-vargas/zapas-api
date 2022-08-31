using Microsoft.EntityFrameworkCore.Metadata;

namespace Zapas.Data.Models
{
    [Table("Races")]
    public class Race
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime RaceStart { get; set; }

        [Required]
        [Column(TypeName ="decimal(7,2)")]
        public decimal Distance { get; set; }

        [Required]
        public int SpeedAvg { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int HRAvg { get; set; }

        public string? UserId { get; set; }

        [ForeignKey(nameof(Zapa))]
        public Guid ZapaId { get; set; }

        public Zapa? Zapa { get; set; }

        [ForeignKey(nameof(RaceType))]
        public Guid RaceTypeId { get; set; }

        public RaceType? RaceType { get; set; }

        [ForeignKey(nameof(Place))]
        public Guid? PlaceId { get; set; }

        public Place? Place { get; set; }

        [MaxLength(255)]
        public String? Description { get; set; }

        [MaxLength(255)]
        public String? Comments { get; set; }
    }
}

