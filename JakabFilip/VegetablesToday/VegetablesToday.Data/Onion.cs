using System;
using VegetablesToday.Data.Base;
using VegetablesToday.Data.Enums;

namespace VegetablesToday.Data.DataTypes
{
	public class Onion : ProductOfNature
	{
		public Onion() : base("Onion", Kind.Vegetable, MeasuringBy.PerWeight, Enums.WeightUnit.Ton)
		{

		}
	}
}