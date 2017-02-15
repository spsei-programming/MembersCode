using System;
using VegetablesToday.Data.Base;
using VegetablesToday.Data.Enums;

namespace VegetablesToday.Data.DataTypes
{
	public class Apple : ProductOfNature
	{
		public Apple() : base("Apple", Kind.Fruit, MeasuringBy.PerWeight, Enums.WeightUnit.Kilogram)
		{

		}
	}
}