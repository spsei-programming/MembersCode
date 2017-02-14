using System;
using VegetablesToday.Data.Base;
using VegetablesToday.Data.Enums;

namespace VegetablesToday.Data.DataTypes
{
	public class Orange : ProductOfNature
	{
		public Orange() : base("Orange", Kind.Fruit, MeasuringBy.PerWeight, Enums.WeightUnit.Kilogram)
		{

		}
	}
}