using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Kayak
{
	public class CountryPicker : Picker
	{
		public static BindableProperty ItemsSourceProperty =
			BindableProperty.Create<CountryPicker, IEnumerable>(o => o.ItemsSource, default(IEnumerable), propertyChanged: OnItemsSourceChanged);

		public static BindableProperty SelectedItemProperty =
			BindableProperty.Create<CountryPicker, object>(o => o.SelectedItem, default(object), propertyChanged: OnSelectedItemChanged);

		public IEnumerable ItemsSource
		{
			get { return (IEnumerable)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		public object SelectedItem
		{
			get { return (object)GetValue(SelectedItemProperty); }
			set { SetValue(SelectedItemProperty, value); }
		}

		private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
		{
			var picker = bindable as CountryPicker;
			picker.Items.Clear();
			if (newvalue != null)
			{
				//now it works like "subscribe once" but you can improve
				foreach (var item in newvalue)
				{
					var country = (Country)item; //not ideal
					picker.Items.Add(country?.Name);
				}
			}
		}

		private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
		{
			if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
			{
				SelectedItem = null;
			}
			else
			{
				List<Country> countriesList = (System.Collections.Generic.List<Kayak.Country>)ItemsSource;
				SelectedItem = countriesList[SelectedIndex];
			}
		}

		private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
		{
			var picker = bindable as CountryPicker;
			if (newvalue != null)
			{
				
				picker.SelectedIndex = picker.Items.IndexOf(newvalue.ToString());
			}
			else { 
				picker.SelectedIndex = picker.Items.IndexOf(oldvalue.ToString());
			}
		}
	}
}