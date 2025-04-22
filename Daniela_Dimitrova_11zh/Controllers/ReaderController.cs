using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daniela_Dimitrova_11zh.Data;
using Daniela_Dimitrova_11zh.Data.Models;

namespace Daniela_Dimitrova_11zh.Controllers
{
	public class ReaderController
	{
		public Context context;
		public ReaderController(Context con)
		{
			this.context = con;
		}

		public List<Reader> GetAll()
		{
			return context.Readers.ToList();
		}
		public Reader GetById(int id)
		{
			return context.Readers.Find(id);
		}
		public void AddReader(Reader reader)
		{
			context.Readers.Add(reader);
			context.SaveChanges();
		}
		public void DeleteReader(int id)
		{
			var readerToDelete = context.Readers.Find(id);
			if (readerToDelete == null)
			{
				throw new ArgumentException("Reader wasn't found.");
			}
			context.Readers.Remove(readerToDelete);
			context.SaveChanges();
		}
		public void UpdateReader(Reader reader)
		{
			Reader currentReader = context.Readers.Find(reader.Id);
			if (currentReader == null)
			{
				throw new ArgumentException("Reader wasn't found.");
			}
			context.Entry(currentReader).CurrentValues.SetValues(reader);
			context.SaveChanges();
		}
	}
}
