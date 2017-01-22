using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Kayak
{
	public partial class AirportSearchPage : BasePage
	{
		public SearchResultViewModel ViewModel
		{
			get;
			set;
		}

		readonly LabelCountries Control;

		public AirportSearchPage(LabelCountries control)
		{
			this.Control = control;
			this.Title = "Search Airport";
			var airportSearchViewModel = new AirportSearchViewModel();
			airportSearchViewModel.ParentViewModel = control.ParentViewModel;
			BindingContext = airportSearchViewModel;
			InitializeComponent();

			CountryListView.ItemSelected += CountryListView_ItemSelected;
		}

		//Can be achived with binding
		void CountryListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var selectedCountry = (Country)e.SelectedItem;
			if (this.Control != null)
			{
				this.Control.SelectedCountry = selectedCountry;
				Control.ParentViewModel.Navigation.PopAsync();
			}
		}
	}
}
