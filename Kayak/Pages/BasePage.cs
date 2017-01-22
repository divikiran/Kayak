using System;

using Xamarin.Forms;

namespace Kayak
{
	public class BasePage : ContentPage
	{
		public BasePage()
		{
			this.Title = "Kayak";
			//this.BackgroundImage = "kayak.jpg";

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (BindingContext != null && BindingContext is BaseViewModel)
			{
				var vm = (BaseViewModel)BindingContext;
				vm?.OnAppearing();
			}
		}
		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			if (BindingContext != null && BindingContext is BaseViewModel)
			{
				var vm = (BaseViewModel)BindingContext;
				vm?.OnDisappearing();
			}
		}
	}
}

