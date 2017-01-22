using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Kayak.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			var appPort = new App();
			App.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;
			LoadApplication(appPort);
			return base.FinishedLaunching(app, options);
		}

		//Background fetch
		public override void PerformFetch(UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
		{
			base.PerformFetch(application, completionHandler);

			//List country endpoint



		}
	}
}
