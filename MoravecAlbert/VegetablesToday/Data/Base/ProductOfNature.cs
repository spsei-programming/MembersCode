using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using Data.Enums;

namespace Data.Base
{
	[Serializable]
	[XmlRoot("Polozka")]
	public class ProductOfNature
	{
		private DateTime bestBefore;

		public Kinds Kind { get; protected set; }
		public Measurings MeasuringBy { get; protected set; }
		[XmlAttribute("Vaha")]
		public WeightUnits? WeightUnit { get; set; }
		[XmlText]
		public decimal Amount { get; set; }
		[XmlAttribute("Nazev")]
		public string Name { get; protected set; }
		public DateTime PurchaseDate { get; set; }
		public decimal PurchasePricePerUnit { get; set; }
		[XmlAttribute("Cena")]
		public decimal TotalPrice => Math.Round(Amount * PurchasePricePerUnit, 1);

		public DateTime BestBefore
		{
			get { return bestBefore; }
			set
			{
				if (value < PurchaseDate) throw new ArgumentOutOfRangeException("PurchaseDate", "Best before must be after purchase date");
				bestBefore = value;
			}
		}

		public ProductOfNature(string name, Kinds kind, Measurings measuringBy, WeightUnits? weightUnit)
		{
			Kind = kind;
			MeasuringBy = measuringBy;
			WeightUnit = weightUnit;
			Name = name;
		}
	}
}