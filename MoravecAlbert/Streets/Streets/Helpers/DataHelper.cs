using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Streets.Models;

namespace Streets.Helpers
{
	public static class DataHelper
	{
		private static BinaryFormatter serializer = new BinaryFormatter();

		public static List<Street> Load(string filePath)
		{
			using (Stream stream = File.OpenRead(filePath))
			{
				return serializer.Deserialize(stream) as List<Street>;
			}
		}

		public static void Save(List<Street> streets, string filePath)
		{
			using (Stream stream = File.OpenWrite(filePath))
			{
				serializer.Serialize(stream, streets);
			}
		}
	}
}