using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace Kayak
{
	public partial class BindablePicker : Picker
	{

		public BindablePicker()
		{
			this.SelectedIndexChanged += OnSelectedIndexChanged;
		}

		public static BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(IList), typeof(BindablePicker), default(IList), BindingMode.TwoWay, propertyChanged: OnItemsSourceChanged);

		public static BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem", typeof(Country), typeof(BindablePicker), default(Country), BindingMode.TwoWay, propertyChanged: UpdateSelected);

		public string DisplayMember { get; set; }

		public IList ItemsSource
		{
			get { return (IList)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		public object SelectedItem
		{
			get { return (object)GetValue(SelectedItemProperty); }
			set { SetValue(SelectedItemProperty, value); }
		}

		private static void OnItemsSourceChanged(BindableObject bindable, object oldvalue, object newvalue)
		{
			var picker = bindable as BindablePicker;

			if (picker != null)
			{
				picker.Items.Clear();
				if (newvalue == null) return;
				foreach (var item in (IList)newvalue)
				{
					var type = item.GetType();
					var prop = type.GetRuntimeProperty("Name");
					picker.Items.Add(prop.GetValue(item).ToString());
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
				SelectedItem = ItemsSource[SelectedIndex];
			}
		}

		private static void UpdateSelected(BindableObject bindable, object oldvalue, object newvalue)
		{

			var picker = bindable as BindablePicker;
			if (picker != null)
				if (picker.ItemsSource != null)
					if (picker.ItemsSource.Contains(picker.SelectedItem))
						picker.SelectedIndex = picker.ItemsSource.IndexOf(picker.SelectedItem);
					else
						picker.SelectedIndex = -1;

		}

	}
}