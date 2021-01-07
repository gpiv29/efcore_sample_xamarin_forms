using Autofac;
using EFCoreSampleXamarinForms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreSampleXamarinForms.UWP.Services
{
	public class UWPAutofacService : AutofacService
	{
		protected override void RegisterDependencies(ContainerBuilder cb)
		{
			base.RegisterDependencies(cb);

			cb.RegisterType<FileHelper>().As<IFileHelper>();
		}
	}
}
