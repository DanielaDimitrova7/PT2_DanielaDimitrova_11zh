using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniela_Dimitrova_11zh.Data.Models
{
	public class Genre
	{
		[Key]
		public int Id { get; set; }
		[Required] [StringLength(20)]
		public string Name { get; set; }
		public List<Reader> Readers { get; set; } 
		public Genre()
		{
			Readers = new List<Reader>();
		}
	}
}
