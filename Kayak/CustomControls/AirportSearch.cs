using System;
using Xamarin.Forms;

namespace Kayak
{
	public class AirportSearch : StackLayout
	{
		//public static BindableProperty NameTextProperty = BindableProperty.Create("NameText", typeof(string), typeof(AirportSearch), default(string));
		//public string NameText
		//{
		//	get { return (string)GetValue(NameTextProperty); }
		//	set { SetValue(NameTextProperty, value); }
		//}

		public AirportSearch()
		{
			HorizontalOptions = LayoutOptions.FillAndExpand;
			VerticalOptions = LayoutOptions.FillAndExpand;

			var airportTextBox = new Label();
			airportTextBox.HeightRequest = 20;
			airportTextBox.SetBinding(Label.TextProperty,new Binding("SelectedCountry.Name"));
			airportTextBox.TextColor = Color.Gray;

			var frame = new Frame
			{
				Content = airportTextBox,
				OutlineColor = Color.Silver,
				HasShadow = false,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			TapGestureRecognizer tapped = new TapGestureRecognizer();
			tapped.SetBinding(TapGestureRecognizer.CommandProperty, new Binding("NavigateToAirportSearchCommand"));
			//tapped.SetBinding(TapGestureRecognizer.CommandParameterProperty, NameTextProperty);
			frame.GestureRecognizers.Add(tapped);

			Children.Add(frame);
		}
	}
}
