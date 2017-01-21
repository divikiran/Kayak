using System;
using Xamarin.Forms;

namespace Kayak
{
	public class LocationPickerEntry : StackLayout
	{
		public LocationPickerEntry()
		{

			this.Orientation = StackOrientation.Horizontal;
			this.VerticalOptions = LayoutOptions.CenterAndExpand;
			this.HorizontalOptions = LayoutOptions.FillAndExpand;

			var locationLabel = new Label()
			{
				FontSize = 12f,
				MinimumWidthRequest = 50,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			locationLabel.SetBinding(Label.TextProperty, new Binding("LocationText"));

			var locationEntry = new BindablePicker() { HorizontalOptions = LayoutOptions.FillAndExpand };
			locationEntry.SetBinding(BindablePicker.ItemsSourceProperty, new Binding("Countries"));
			locationEntry.SetBinding(BindablePicker.SelectedItemProperty, new Binding("SelectedCountry"));

			Children.Add(locationLabel);
			Children.Add(locationEntry);
		}
	}
}
