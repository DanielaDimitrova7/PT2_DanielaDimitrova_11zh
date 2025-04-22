using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daniela_Dimitrova_11zh.Data.Models;
using Daniela_Dimitrova_11zh.Data;

namespace Daniela_Dimitrova_11zh.Data
{
	public class Context : DbContext
	{
		public DbSet<Reader> Readers { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Genre> Genres { get; set; }

		public Context() { }
		public Context(DbContextOptions options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.ConnectionString);
			}
			base.OnConfiguring(optionsBuilder);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Reader>().
				HasMany(r => r.Books).WithMany(b => b.Readers);
			
			modelBuilder.Entity<Book>().
				HasMany(b => b.Genres);
			
			modelBuilder.Entity<Genre>().
				HasMany(g => g.Readers);
		}
	}
}
