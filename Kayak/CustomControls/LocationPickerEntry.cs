using System;
using Xamarin.Forms;

namespace Kayak
{
	public class LocationPickerEntry : StackLayout
	{
		public LocationPickerEntry()
		{
			var locationLabel = new Label()
			{
				FontSize = 12f,
				MinimumWidthRequest = 50,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			locationLabel.SetBinding(Label.TextProperty, new Binding("LocationText"));

			var locationEntry = new CountryPicker() { HorizontalOptions = LayoutOptions.FillAndExpand };
			locationEntry.SetBinding(CountryPicker.ItemsSourceProperty, new Binding("Countries"));
			locationEntry.SetBinding(CountryPicker.SelectedItemProperty, new Binding("SelectedCountry"));

			this.Orientation = StackOrientation.Horizontal;
			this.VerticalOptions = LayoutOptions.CenterAndExpand;
			this.HorizontalOptions = LayoutOptions.FillAndExpand;

			Children.Add(locationLabel);
			Children.Add(locationEntry);
		}
	}
}
