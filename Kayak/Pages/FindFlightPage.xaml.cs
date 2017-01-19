using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Kayak
{
	public partial class FindFlightPage : BasePage
	{

		public FindFlightsViewModel ViewModel
		{
			get;
			set;
		}

		public FindFlightPage()
		{
			InitializeComponent();
			ViewModel = new FindFlightsViewModel();
			KayakGrid.WidthRequest = App.ScreenWidth;
			BindingContext = ViewModel;
		}

	}
}
