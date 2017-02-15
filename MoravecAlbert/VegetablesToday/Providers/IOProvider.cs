using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Data.Base;
using Newtonsoft.Json;

namespace Providers
{
	public class IOProvider
	{
		private List<ProductOfNature> stock;

		JsonSerializer jsonSerializer = new JsonSerializer();
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductOfNature));

		public IOProvider(List<ProductOfNature> stock)
		{
			this.stock = stock;
		}

		public void SaveJSON(string path)
		{
			using (StreamWriter streamWriter = new StreamWriter(path))
			using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
			{
				jsonSerializer.Serialize(jsonWriter, stock);
			}
		}

		public List<ProductOfNature> LoadJson(string path)
		{
			using (StreamReader streamReader = new StreamReader(path))
			using (JsonReader jsonReader = new JsonTextReader(streamReader))
			{
				return jsonSerializer.Deserialize(jsonReader) as List<ProductOfNature>;
			}
		}

		public ProductOfNature ImportVendorXml(string path)
		{
			using (StreamReader streamReader = new StreamReader(path))
			{
				return xmlSerializer.Deserialize(streamReader) as ProductOfNature;
			}
		}

		public void ExportVendorXml(string path)
		{
			using (StreamWriter streamWriter = new StreamWriter(path))
			{
				xmlSerializer.Serialize(streamWriter, stock);
			}
		}
	}
}