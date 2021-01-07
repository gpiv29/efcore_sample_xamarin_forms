using EFCoreSampleXamarinForms.Data;
using EFCoreSampleXamarinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Xamarin.Forms;

namespace EFCoreSampleXamarinForms
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			Task.Run(async () =>
			{
				await Task.Delay(2000);

				TestHelper.RunTests();
			});
		}
		
	}
}
