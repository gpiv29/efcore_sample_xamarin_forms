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
			//the memory used by this app
			Debug.WriteLine($"Current memory usage: {Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024} MB");
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
			//the memory used by this app. suspend and reopen to trigger this output on android or iOS
			Debug.WriteLine($"Current memory usage: {Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024} MB");
		}
	}
}
