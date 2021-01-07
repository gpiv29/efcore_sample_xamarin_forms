using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSampleXamarinForms.Services
{
	public class DbContextLoggerFactory : ILoggerFactory
	{
		public void AddProvider(ILoggerProvider provider)
		{
			;
		}

		public ILogger CreateLogger(string categoryName)
		{
			return new DbContextLogger();
		}

		public void Dispose()
		{
			;
		}
	}
}
