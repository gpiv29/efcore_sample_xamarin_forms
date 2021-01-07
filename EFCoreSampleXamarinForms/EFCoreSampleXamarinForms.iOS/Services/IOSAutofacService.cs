using System;
using Autofac;
using EFCoreSampleXamarinForms.Services;

namespace EFCoreSampleXamarinForms.iOS.Services
{
	public class IOSAutofacService : AutofacService
	{
		protected override void RegisterDependencies(ContainerBuilder cb)
		{
			base.RegisterDependencies(cb);

			cb.RegisterType<FileHelper>().As<IFileHelper>();
		}
	}
}
