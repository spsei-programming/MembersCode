using System;
using VegetablesToday.Data.Enums;

namespace VegetablesToday.Data.Base
{
	public class ProductOfNature
	{
		private DateTime bestBefore;

		public Kind Kind { get; protected set; }

		public string Name { get; protected set; }

		public MeasuringBy MeasuringBy { get; protected set; }

		public WeightUnit? WeightUnit { get; protected set; }

		public decimal Amount { get; set; }

		public DateTime PurchaseDate { get; set; }

		public int PurchasePricePerUnit { get; set; }

		public decimal TotalPrice => Math.Round(Amount * PurchasePricePerUnit, 1);

		public DateTime BestBefore
		{
			get { return bestBefore; }
			set
			{
				if (value < PurchaseDate)
					throw new ArgumentOutOfRangeException("BestBefore cannot be smaller than Purchase Date", new NullReferenceException());
				bestBefore = value;
			}
		}

		protected ProductOfNature(string name, Kind kind, MeasuringBy measuringBy, WeightUnit? weightUnit)
		{
			Kind = kind;
			Name = name;
			MeasuringBy = measuringBy;
			WeightUnit = weightUnit;
		}
	}
}