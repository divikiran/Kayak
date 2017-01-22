using System;
using Xamarin.Forms;

namespace Kayak
{
	public class SearchResultViewModel : BaseViewModel
	{
		public FindFlightsViewModel ParentViewModel
		{
			get;
			set;
		}

		string _currentDateTime = DateTime.Now.ToString("F");
		public string CurrentDateTime
		{
			get
			{
				return _currentDateTime;
			}

			set
			{
				_currentDateTime = value;
				RaisePropertyChanged("CurrentDateTime");
			}
		}
		string _tripType;
		public string TripType
		{
			get
			{
				return _tripType;
			}

			set
			{
				_tripType = value;
				RaisePropertyChanged("TripType");
			}
		}

		string _cityFrom;
		public string CityFrom
		{
			get
			{
				return _cityFrom;
			}

			set
			{
				_cityFrom = value;
				RaisePropertyChanged("CityFrom");
			}
		}
		string _cityTo;
		public string CityTo
		{
			get
			{
				return _cityTo;
			}

			set
			{
				_cityTo = value;
				RaisePropertyChanged("CityTo");
			}
		}
		string _selectedDateRange;

		public string SelectedDateRange
		{
			get
			{
				return _selectedDateRange;
			}

			set
			{
				_selectedDateRange = value;
				RaisePropertyChanged("SelectedDateRange");
			}
		}

		bool UpdateDateTime()
		{
			CurrentDateTime = DateTime.Now.ToString("F");
			return true;
		}

		public SearchResultViewModel()
		{
			var minutes = TimeSpan.FromSeconds(1);
			Device.StartTimer(minutes, UpdateDateTime);
		}

		public override void OnAppearing()
		{
			base.OnAppearing();

			TripType = "Trip Type : " + ParentViewModel?.RoundTripText;
			CityFrom = "From: " + Environment.NewLine + ParentViewModel?.FromCountries?.SelectedCountry?.Name;
			CityTo = "To: " + Environment.NewLine + ParentViewModel?.ToCountries?.SelectedCountry?.Name;

			SelectedDateRange = "Travel On: " + ParentViewModel.FromDate.ToString("D");
			if (ParentViewModel?.RoundTripText == "Round Trip")
			{
				SelectedDateRange = "Selected date range: " + Environment.NewLine;
				SelectedDateRange += "From: " + ParentViewModel.FromDate.ToString("D") + Environment.NewLine;
				SelectedDateRange += "To: " + ParentViewModel.ToDate.ToString("D") + Environment.NewLine;
			}
		}
	}
}
