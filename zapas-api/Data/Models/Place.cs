using System;
namespace Zapas.Data.Models
{
	[Table("Places")]
	public class Place
	{
		[Key]
		[Required]
		public Guid Id { get; set; }

		[Required]
		[MaxLength(100)]
		public String? Name { get; set; }
	}
}

