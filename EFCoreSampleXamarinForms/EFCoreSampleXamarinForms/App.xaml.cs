using Autofac;
using EFCoreSampleXamarinForms.Services;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EFCoreSampleXamarinForms
{
	public partial class App : Application
	{
		public App(AutofacService autofacService)
		{
			InitializeComponent();

			AppContainer.GlobalContainer = autofacService.CreateContainer();

			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
			Debug.WriteLine("================ APP START ===============");
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
			
		}
	}
}
