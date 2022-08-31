using Microsoft.EntityFrameworkCore;

namespace Zapas.Data.Models
{
    [Table("RaceTypes")]
    [Index(nameof(Name), IsUnique = true)]
    public class RaceType
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public String? Name { get; set; }
    }
}

