using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniela_Dimitrova_11zh.Data.Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }
		[Required][StringLength(50)]
		public string Title { get; set; }
		[Required][StringLength(50)]
		public string Author { get; set; }
		public List<Reader> Readers { get; set;}
		public List<Genre> Genres { get; set;}

		public Book()
		{
			Readers = new List<Reader>();
			Genres = new List<Genre>();
		}
	}
}
