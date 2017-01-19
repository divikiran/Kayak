using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using System.Linq;
namespace Kayak
{
	public class FindFlightsViewModel : BaseViewModel
	{
		private List<Country> _countries;
		public List<Country> Countries
		{
			get { return _countries; }
			set
			{
				_countries = value;
				RaisePropertyChanged("Countries");
			}
		}

		private LabelCountries _fromCountries;
		public LabelCountries FromCountries
		{
			get { return _fromCountries; }
			set
			{
				_fromCountries = value;
				RaisePropertyChanged("FromCountries");
			}
		}

		private LabelCountries _toCountries;
		public LabelCountries ToCountries
		{
			get { return _toCountries; }
			set
			{
				_toCountries = value;
				RaisePropertyChanged("ToCountries");
			}
		}

		public FindFlightsViewModel()
		{
			if (Countries == null)
			{
				Countries = new List<Country>();
				IReadCountriesJson countriesReadText = DependencyService.Get<IReadCountriesJson>();
				Countries = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Country>>(countriesReadText?.ReadAllText());
				var SortedCountries = Countries.Where(w=> !string.IsNullOrEmpty(w.Name) && w.Type == "airport").OrderBy(o => o.Name).ToList();

				var defaultSelected = SortedCountries.FirstOrDefault();
				FromCountries = new LabelCountries
				{
					LocationText = "From",
					Countries = SortedCountries,
					SelectedCountry = defaultSelected,
				};
				ToCountries = new LabelCountries
				{
					LocationText = "To",
					Countries = SortedCountries,
					SelectedCountry = defaultSelected,
				};
			}
		}

		public override void OnAppearing()
		{
			base.OnAppearing();
			Debug.WriteLine("OnAppearing");
		}

		public override void OnDisappearing()
		{
			base.OnDisappearing();
			Debug.WriteLine("OnDisappearing");
		}
	}
}
