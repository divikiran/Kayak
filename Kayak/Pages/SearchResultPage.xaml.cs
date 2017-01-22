using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Kayak
{
	public partial class SearchResultPage : BasePage
	{
		public SearchResultViewModel ViewModel
		{
			get;
			set;
		}
		public SearchResultPage(FindFlightsViewModel parentViewModel)
		{
			this.Title = "Search Result";
			ViewModel = new SearchResultViewModel();
			ViewModel.ParentViewModel = parentViewModel;
			BindingContext = ViewModel;
			InitializeComponent();
		}
	}
}
