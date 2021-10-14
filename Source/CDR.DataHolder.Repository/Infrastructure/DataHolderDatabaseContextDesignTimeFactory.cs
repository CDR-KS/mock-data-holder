﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CDR.DataHolder.Repository.Infrastructure
{
	/// <summary>
	/// This is the DB context initialisation for the tooling such as migrations.
	/// When the tooling runs the migration, it looks first for a class that implements IDesignTimeDbContextFactory and if found, 
	/// it will use that for configuring the context. Runtime behavior is not affected by any configuration set in the factory class.
	/// </summary>
	public class DataHolderDatabaseContextDesignTimeFactory : IDesignTimeDbContextFactory<DataHolderDatabaseContext>
	{
		public DataHolderDatabaseContextDesignTimeFactory()
		{
			// A parameter-less constructor is required by the EF Core CLI tools.
		}

		public DataHolderDatabaseContext CreateDbContext(string[] args)
		{
			// Copy the connection string into here to create the Initial Migration using EFCore tools
			// eg. Server=(localdb)\\MSSQLLocalDB;Database=cdr-mdh;Integrated Security=true
			// From Package Manager Console > Select Repository as the start up project
			// Delete any existing migrations and ContextModelSnapshots
			// execute Add-Migration "Init"
			// database will be created and seeded when solution is started
			var connectionString = "";
			if (string.IsNullOrEmpty(connectionString))
			{
				throw new InvalidOperationException("The connection string was not set in the CreateDbContext() method.");
			}
			var options = new DbContextOptionsBuilder<DataHolderDatabaseContext>().UseSqlServer(connectionString).Options;
			return new DataHolderDatabaseContext(options);
		}
	}

}
