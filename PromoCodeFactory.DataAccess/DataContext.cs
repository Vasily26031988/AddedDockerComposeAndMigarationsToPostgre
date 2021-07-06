using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Core.Domain.Administration;
using PromocodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromoCodeFactory.DataAccess
{
	public class DataContext
		: DbContext
	{
		public DbSet<PromoCode> PromoCodes { get; set; }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<Preference> Preferences { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<Employee> Employees { get; set; }

		public DataContext()
		{

		}

		public DataContext(DbContextOptions<DataContext> options)
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CustomerPreference>()
				.HasKey(bc => new { bc.CustomerId, bc.PreferenceId });
			modelBuilder.Entity<CustomerPreference>()
				.HasOne(bc => bc.Customer)
				.WithMany(b => b.Preferences)
				.HasForeignKey(bc => bc.CustomerId);
			modelBuilder.Entity<CustomerPreference>()
				.HasOne(bc => bc.Preference)
				.WithMany()
				.HasForeignKey(bc => bc.PreferenceId);
		}
	}
}
