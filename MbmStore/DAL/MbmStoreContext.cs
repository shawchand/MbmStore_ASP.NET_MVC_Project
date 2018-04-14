using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace MbmStore.DAL
{
	public class MbmStoreContext : DbContext
	{
		public MbmStoreContext() : base("MbmStoreContext") { }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<Phone> Phones { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<MusicCD> MusicCDs { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Track> Tracks { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			//Configure Invoice Column 
			modelBuilder.Entity<Invoice>()
				.Property(p => p.OrderDate)
				.HasColumnType("datetime2");
		}
	}
}