using System;
using System.IO;
using Kayak.iOS;
using Xamarin.Forms;

[assembly:Dependency(typeof(ReadCountriesJson))]
namespace Kayak.iOS
{
	public class ReadCountriesJson : IReadCountriesJson
	{

		public string ReadAllText()
		{
			var countriesString = File.ReadAllText("airports.json");
			return countriesString;
		}
	}
}
