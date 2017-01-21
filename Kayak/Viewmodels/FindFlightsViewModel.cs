using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Kayak
{
	public class FindFlightsViewModel : BaseViewModel
	{
		INavigation Navigation;

		public ICommand SwapCommand { get; private set;}

		async Task SwapCommandAction(object f)
		{
			var thirdVariable = ToCountries.SelectedCountry;
			ToCountries.SelectedCountry = FromCountries.SelectedCountry;
			FromCountries.SelectedCountry = thirdVariable;
		}

		public ICommand FindFlightsSearchPage { get; private set;}

		async Task FindFlightsSearchAction(object obj)
		{
			await Navigation.PushAsync(new SearchResultPage(this));
		}

		string _fromDateText = "From: ";
		public string FromDateText
		{
			get
			{
				return _fromDateText;
			}

			set
			{
				_fromDateText = value;
				RaisePropertyChanged("FromDateText");
			}
		}

		string _toDateText = "To: ";
		public string ToDateText
		{
			get
			{
				return _toDateText;
			}

			set
			{
				_toDateText = value;
				RaisePropertyChanged("ToDateText");
			}
		}

		bool _toDateVisibility = true;
		public bool ToDateVisibility
		{
			get
			{
				return _toDateVisibility;
			}

			set
			{
				_toDateVisibility = value;
				RaisePropertyChanged("ToDateVisibility");
			}
		}

		bool _roundTrip = true;
		public bool RoundTrip
		{
			get { return _roundTrip; }
			set { 
				_roundTrip = value;
				if (_roundTrip)
				{
					RoundTripText = "Round Trip";
					ToDateVisibility = true;
					FromDateText = "From: ";
					//ToDate = ToDate == null ? DateTime.Now : ToDate;
				}
				else {
					RoundTripText = "One way";
					ToDateVisibility = false;
					FromDateText = "Travel on: ";
					ToDate = FromDate;
				}
				RaisePropertyChanged("RoundTrip"); 
			}
		}

		string _roundTripText = " Round trip";
		public string RoundTripText
		{
			get { return _roundTripText; }
			set {
				_roundTripText = value; 
				RaisePropertyChanged("RoundTripText"); 
			}
		}

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

		DateTime _fromDate;
		public DateTime FromDate
		{
			get
			{
				return _fromDate;
			}

			set
			{
				_fromDate = value;
				RaisePropertyChanged("FromDate");
			}
		}

		DateTime _toDate;
		public DateTime ToDate
		{
			get
			{
				return _toDate;
			}

			set
			{
				_toDate = value;
				RaisePropertyChanged("ToDate");
			}
		}

		DateTime _minimumDate;
		public DateTime MinimumDate
		{
			get
			{
				return _minimumDate;
			}

			set
			{
				_minimumDate = value;
				RaisePropertyChanged("MinimumDate");
			}
		}

		DateTime _maximumDate;
		public DateTime MaximumDate
		{
			get
			{
				return _maximumDate;
			}

			set
			{
				_maximumDate = value;
				RaisePropertyChanged("MaximumDate");
			}
		}

		public FindFlightsViewModel(INavigation navigation)
		{
			this.Navigation = navigation;
			ToDate = DateTime.Now;
			FromDate = DateTime.Now;

			MinimumDate = DateTime.Now;
			MaximumDate = new DateTime(2020, 12, 31);
			SwapCommand = new Command(async (f) => await SwapCommandAction(f));
			FindFlightsSearchPage = new Command(async (f) => await FindFlightsSearchAction(f));
			if (Countries == null)
			{
				Countries = new List<Country>();
				IReadCountriesJson countriesReadText = DependencyService.Get<IReadCountriesJson>();
				Countries = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Country>>(countriesReadText?.ReadAllText());
				var SortedCountries = Countries.Where(w=> !string.IsNullOrEmpty(w.Name) && w.Type == "airport").OrderBy(o => o.Name).ToList();

				var defaultSelected = SortedCountries.FirstOrDefault();
				FromCountries = new LabelCountries("From")
				{
					Countries = SortedCountries
				};
				ToCountries = new LabelCountries("To")
				{
					Countries = SortedCountries
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
