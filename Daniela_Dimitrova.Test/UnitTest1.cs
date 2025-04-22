using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Daniela_Dimitrova_11zh.Controllers;
using Daniela_Dimitrova_11zh.Data;
using Daniela_Dimitrova_11zh.Data.Models;
using NUnit.Framework.Legacy;

namespace Daniela_Dimitrova.Test
{
	public class Tests
	{
		private Context context;
		private ReaderController controller;
		[SetUp]
		public void Setup()
		{
			var options = new DbContextOptionsBuilder<Context>().
		UseInMemoryDatabase(databaseName: "BooksAppTestDB").
		Options;

			context = new Context(options);
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
			
			Reader reader = new Reader
			{
				Id = 1,
				FullName = "Reader1",
				Age = 20,
				Email = "reader@gmail.com",
				PhoneNumber = "1234567890",
			};
			context.Readers.Add(reader);
			context.SaveChanges();

			controller = new ReaderController(context);
		}

		[Test]
		public void GetAll_ReturnsReaders()
		{
			var result = controller.GetAll();
			ClassicAssert.AreEqual(1, result.Count);
			ClassicAssert.AreEqual("Reader1", result[0].FullName);
		}
		[Test]
		
		public void Get_ValidId_ReturnsReader()
		{
			var res = controller.GetById(1);
			ClassicAssert.IsNotNull(res);
			ClassicAssert.AreEqual(20, res.Age);
		}
		[Test]
		public void AddReader_AddsReaderSuccessfully()
		{
			Reader readerAdded = new Reader
			{
				Id = 2,
				FullName = "Reader2",
				Age = 40,
				Email = "reader2@gmail.com",
				PhoneNumber = "0000000000",
			};
			controller.AddReader(readerAdded);
			var added = context.Readers.FirstOrDefault(r => r.FullName == "Reader2");
			ClassicAssert.AreEqual(40, added.Age);
		}
		[Test]

		public void UpdateUser_ExistingUser_UpdatesSuccessfully()
		{
			var originalReader = new Reader
			{
				Id = 3,
				FullName = "Reader3",
				Age = 25,
				Email = "reader3@gmail.com",
				PhoneNumber = "1234567890"
			};
			context.Readers.Add(originalReader);
			context.SaveChanges();

			var updatedReader = new Reader
			{
				Id = 3,
				FullName = "Reader3Updated",
				Age = 26,
				Email = "reader3up@gmail.com",
				PhoneNumber = "1111111111"
			};
			controller.UpdateReader(updatedReader);

			var updated = context.Readers.FirstOrDefault(r => r.Id == 3);
			ClassicAssert.IsNotNull(updated);
			ClassicAssert.AreEqual("Reader3Updated", updated.FullName);
			ClassicAssert.AreEqual(26, updated.Age);
			ClassicAssert.AreEqual("reader3up@gmail.com", updated.Email);
		}
	}
}
