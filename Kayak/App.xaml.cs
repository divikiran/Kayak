using Xamarin.Forms;

namespace Kayak
{
	public partial class App : Application
	{
		static public int ScreenWidth;
		public App()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new FindFlightPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
