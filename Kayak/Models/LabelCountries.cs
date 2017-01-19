using System;
using System.Collections.Generic;

namespace Kayak
{
	public class LabelCountries: BaseViewModel
	{
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
			get { return _selectedCountry;}
			set
			{
				_selectedCountry = value;
				RaisePropertyChanged("SelectedCountry");
			}
		}
	}
}
