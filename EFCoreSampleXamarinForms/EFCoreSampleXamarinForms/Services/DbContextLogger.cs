using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EFCoreSampleXamarinForms.Services
{
	public class DbContextLogger : ILogger, IDisposable
	{

		public IDisposable BeginScope<TState>(TState state)
		{
			return this;
		}

		public void Dispose()
		{
			
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			// Include more if you need to, but it slows EF Core way down
			return logLevel == LogLevel.Critical || logLevel == LogLevel.Error;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			Debug.WriteLine("[" + formatter(state, exception) + "]");
		}
	}
}
