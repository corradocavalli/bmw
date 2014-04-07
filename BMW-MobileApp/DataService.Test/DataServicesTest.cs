using System;
using Bmw.DataServices.Core.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataService.Test
{
	[TestClass]
	public class DataServicesTest
	{
		[TestMethod]
		public async void LoadConfiguration()
		{
			var config = ConfigurationService.Load("http://168.63.109.7/raiwin8/bmw/config.txt");
		}
	}
}
