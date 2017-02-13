using System;
using Data.Enums;

namespace Data.Base
{
	public class ProductOfNature
	{
		private DateTime bestBefore;

		public Kinds Kind { get; protected set; }
		public Measurings MeasuringBy { get; protected set; }
		public WeightUnits? WeightUnit { get; set; }
		public string Name { get; protected set; }
		public decimal Amount { get; set; }
		public DateTime PurchaseDate { get; set; }
		public decimal PurchasePricePerUnit { get; set; }
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

		protected ProductOfNature(string name, Kinds kind, Measurings measuringBy, WeightUnits? weightUnit)
		{
			Kind = kind;
			MeasuringBy = measuringBy;
			WeightUnit = weightUnit;
			Name = name;
		}
	}
}