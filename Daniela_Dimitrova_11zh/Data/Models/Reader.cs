using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniela_Dimitrova_11zh.Data.Models
{
	public class Reader
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[StringLength(50)]
		public string FullName { get; set; }
		[Required]
		[Range(10, 80)]
		public int Age { get; set; }
		[Required]
		[StringLength(20)]
		public string Email { get; set; }
		[Required]
		[StringLength(10, MinimumLength =10)]
		public string PhoneNumber { get; set; }
		public List<Book> Books { get; set; }
		public Reader()
		{
			Books = new List<Book>();
		}
	}
}
