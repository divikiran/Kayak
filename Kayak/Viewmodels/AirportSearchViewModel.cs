using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kayak
{
	public class AirportSearchViewModel : BaseViewModel
	{
		FindFlightsViewModel parentViewModel;

		public FindFlightsViewModel ParentViewModel
		{
			get
			{
				return parentViewModel;
			}

			 set
			{
				parentViewModel = value;
				RaisePropertyChanged("ParentViewModel");
			}
		}

		string _searchText;
		public string SearchText
		{
			get
			{
				return _searchText;
			}

			set
			{
				_searchText = value;
				Task.Factory.StartNew(async () => { 
					await FilterCourtryAction();
				});
				RaisePropertyChanged("SearchText");
			}
		}

		public ICommand FilterCourtryCommand { get; private set; }

		async Task FilterCourtryAction()
		{

			ParentViewModel.CountriesListView = new ObservableCollection<Country>();
			var cs = ParentViewModel?.Countries?.Where(w => !string.IsNullOrEmpty(w.Name) && w.Name.Contains(SearchText))?.ToList();

			foreach (var item in cs)
			{
				ParentViewModel.CountriesListView.Add(item);
			}
		}

		public AirportSearchViewModel()
		{
			FilterCourtryCommand = new Command(async (f) => await FilterCourtryAction());
		}
	}
}
