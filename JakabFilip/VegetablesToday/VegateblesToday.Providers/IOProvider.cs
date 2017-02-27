using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
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

		public List<ProductOfNature> LoadAllDataFromJSON(string path)
		{
			return (List<ProductOfNature>) JsonConvert.DeserializeObject(path);
		}

		public List<ProductOfNature> ImportDataFromXML(string path)
		{
			var provider = new XmlSerializer(typeof(List<ProductOfNature>));

			using (Stream stream = File.OpenRead(path))
			{
				foreach (ProductOfNature nature in (List<ProductOfNature>) provider.Deserialize(stream))
				{
					
				}
			}
		}
	}
}