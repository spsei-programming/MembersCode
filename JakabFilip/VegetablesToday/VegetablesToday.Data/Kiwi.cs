using System;
using VegetablesToday.Data.Base;
using VegetablesToday.Data.Enums;

namespace VegetablesToday.Data.DataTypes
{
	public class Kiwi : ProductOfNature
	{
		public Kiwi() : base("Kiwi", Kind.Fruit, MeasuringBy.PerWeight, Enums.WeightUnit.Gram)
		{

		}
	}
}