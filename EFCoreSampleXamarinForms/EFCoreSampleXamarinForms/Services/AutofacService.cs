using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSampleXamarinForms.Services
{
	public class AutofacService
	{
		public IContainer CreateContainer()
		{
			var containerBuilder = new ContainerBuilder();

			RegisterDependencies(containerBuilder);
			return containerBuilder.Build();
		}

		protected virtual void RegisterDependencies(ContainerBuilder cb)
		{
			// Register cross-platform services here
			cb.RegisterType<CustomDBContextFactory>().SingleInstance();

		}
	}
}
