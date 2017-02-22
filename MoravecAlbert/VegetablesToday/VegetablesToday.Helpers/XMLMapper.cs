using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Data;
using Data.Base;
using Data.Enums;

namespace VegetablesToday.Helpers
{
	public class XMLMapper
	{
		private string[] vegetables = { "okurka", "okurky", "cibule" };
		private string[] fruits = { "jablko", "jablka", "kiwi", "pomeranč", "pomeranče", "ananas", "ananasy" };

		private XmlDocument xml;

		public XMLMapper(string xmlString)
		{
			xml.Load(xmlString);
		}

		public ProductOfNature Map()
		{
			string name = xml.GetElementsByTagName("nazev")[0].Value.ToLower();
			XmlNode weightNode = xml.GetElementsByTagName("vaha")[0];
			string weightUnitString = weightNode.Attributes["mernaJednotka"].Value.ToLower();
			decimal amount, price;
			decimal.TryParse(weightNode.Value, out amount);
			decimal.TryParse(xml.GetElementsByTagName("cena")[0].Value, out price);

			Kinds kind;

			if (vegetables.Contains(name))
				kind = Kinds.Vegetable;
			else if (fruits.Contains(name))
				kind = Kinds.Fruit;


			WeightUnits? weightUnit = null;
			Measurings measuring;

			switch (weightUnitString)
			{
				case "kilo":
					measuring = Measurings.PerWeight;
					weightUnit = WeightUnits.Kilogram;
					break;
				case "kus":
					measuring = Measurings.PerItem;
					break;
			}

			var product = new ProductOfNature(name, kind, measuring, weightUnit);
			product.Amount = amount;
			product.PurchasePricePerUnit = price / amount;

			return product;
		}
	}
}
