using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PromoCodeFactory.DataAccess
{
	class DatabaseContextDesignTimeFactory : IDesignTimeDbContextFactory<DataContext>
	{
		public DataContext CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(new DirectoryInfo("../PromoCodeFactory.WebHost").FullName)
				.AddJsonFile("appsettings.json")
				.AddJsonFile("appsettings.Development.json")
				.AddEnvironmentVariables()
				.Build();

			var builder = new DbContextOptionsBuilder<DataContext>();
			var connectionString = configuration.GetConnectionString("PromocodeFactoryDb");
			Console.WriteLine(connectionString);
			builder.UseNpgsql(connectionString);

			return new DataContext(builder.Options);
		}
    }
}
