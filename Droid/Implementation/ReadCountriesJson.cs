using System;
using System.IO;
using Kayak.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(ReadCountriesJson))]
namespace Kayak.Droid
{
	public class ReadCountriesJson : IReadCountriesJson
	{
		public string ReadAllText()
		{

			//string response;

			//StreamReader strm = new StreamReader(Assets.Open("airports.json"));
			//response = strm.ReadToEnd();

			var countriesString = File.ReadAllText("airports.json");
			return countriesString;
		}
	}
}
