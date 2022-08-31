using Microsoft.EntityFrameworkCore;

namespace Zapas.Data.Models
{
    [Table("Zapas")]
    public class Zapa
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public String? Brand { get; set; }

        [Required]
        [MaxLength(80)]
        public String? Name { get; set; }

        [Required]
        public int Limit { get; set; }

        [Required]
        public DateTime InitialDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public bool IsRetired { get; set; }

        public string? UserId { get; set; }
    }
}

