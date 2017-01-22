using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kayak
{
	public class LabelCountries: BaseViewModel
	{
		public FindFlightsViewModel ParentViewModel;

		public LabelCountries(string locationText, FindFlightsViewModel parentViewModel)
		{
			this.ParentViewModel = parentViewModel;
			LocationText = locationText;

			if (SelectedCountry == null)
			{
				SelectedCountry = new Country() { Name = locationText };
			}

			NavigateToAirportSearchCommand = new Command(async (f) =>
			{
				await NavigateToAirportSearchAction(f);
			});
		}
		private string _locationText;
		public string LocationText
		{
			get { return _locationText; }
			set
			{
				_locationText = value;
				RaisePropertyChanged("LocationText");
			}
		}

		private List<Country> _countries;
		public List<Country> Countries
		{
			get { return _countries; }
			set { _countries = value; 
				RaisePropertyChanged("Countries"); 
			}
		}

		Country _selectedCountry;
		public Country SelectedCountry
		{
			get {
			
				return _selectedCountry;
			}
			set
			{
				_selectedCountry = value;
				RaisePropertyChanged("SelectedCountry");
			}
		}

		public ICommand NavigateToAirportSearchCommand { get; private set; }

		async Task NavigateToAirportSearchAction(object f)
		{
			await ParentViewModel.Navigation.PushAsync(new AirportSearchPage(this));
		}
	}
}
