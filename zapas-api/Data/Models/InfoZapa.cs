using System;
namespace Zapas.Data.Models
{
	public class InfoZapa
	{
        public Guid Id { get; set; }
        public String? Brand { get; set; }
        public String? Name { get; set; }
        public int Limit { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Remaining { get; set; }
        public Guid UserId { get; set; }
    }
}

