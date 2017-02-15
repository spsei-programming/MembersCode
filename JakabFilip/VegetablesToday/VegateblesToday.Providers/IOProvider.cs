using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using VegetablesToday.Data.Base;

namespace VegateblesToday.Providers
{
	public class IOProvider
	{
		public void SaveAllDataToJSON(List<ProductOfNature> allStocks, string path)
		{
			string jsonDatas = JsonConvert.SerializeObject(allStocks);

			File.AppendAllText(path, jsonDatas);
		}

		public List<ProductOfNature> LoadAllDataFromJSON()
		{
			throw new NotImplementedException();
		}

		public List<ProductOfNature> ImportDataFromXML()
		{
			throw new NotImplementedException();
		}
	}
}