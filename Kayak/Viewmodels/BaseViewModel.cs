using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Kayak
{
	public class BaseViewModel:INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		public virtual void OnAppearing() { }
		public virtual void OnDisappearing() { }

		//public void RaisePropertyChanged(string propertyName)
		//{
		//	if (PropertyChanged != null)
		//	{
		//		PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		//	}
		//}

	}
}
