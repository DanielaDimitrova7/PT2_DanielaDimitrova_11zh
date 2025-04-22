using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daniela_Dimitrova_11zh.Data.Models;
using Daniela_Dimitrova_11zh.Data;

namespace Daniela_Dimitrova_11zh.Controllers
{
	public class BookController
	{
		public Context context;
		public BookController(Context con)
		{
			this.context = con;
		}

		public List<Book> GetAll()
		{
			return context.Books.ToList();
		}
		public Book GetById(int id)
		{
			return context.Books.Find(id);
		}
		public void AddBook(Book book)
		{
			context.Books.Add(book);
			context.SaveChanges();
		}
		public void DeleteBook(int id)
		{
			var bookToDelete = context.Books.Find(id);
			if (bookToDelete == null)
			{
				throw new ArgumentException("Book wasn't found.");
			}
			context.Books.Remove(bookToDelete);
			context.SaveChanges();
		}
		public void UpdateBook(Book book)
		{
			Book currentBook = context.Books.Find(book.Id);
			if (currentBook == null)
			{
				throw new ArgumentException("Book wasn't found.");
			}
			context.Entry(currentBook).CurrentValues.SetValues(book);
			context.SaveChanges();
		}
	}
}
