using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Kayak
{
	public partial class SearchResultPage : BasePage
	{
		public FindFlightsViewModel ParentViewModel
		{
			get;
			set;
		}

		public SearchResultViewModel ViewModel
		{
			get;
			set;
		}
		public SearchResultPage(FindFlightsViewModel parentViewModel)
		{
			
			ViewModel = new SearchResultViewModel();
			ViewModel.ParentViewModel = parentViewModel;
			BindingContext = ViewModel;
			InitializeComponent();
		}
	}
}
