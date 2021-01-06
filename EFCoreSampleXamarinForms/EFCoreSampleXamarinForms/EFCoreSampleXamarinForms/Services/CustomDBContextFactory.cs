using EFCoreSampleXamarinForms.Data;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSampleXamarinForms.Services
{
	public class CustomDBContextFactory : IDesignTimeDbContextFactory<CustomDBContext>
	{
		public CustomDBContext CreateDbContext(string[] args)
		{
			var dbContext = new CustomDBContext();
			dbContext.Database.EnsureCreated();
			return dbContext;
		}
	}
}
