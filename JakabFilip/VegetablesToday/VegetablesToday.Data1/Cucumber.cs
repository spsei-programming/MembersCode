using System;
using VegetablesToday.Data.Base;
using VegetablesToday.Data.Enums;

namespace VegetablesToday.Data.DataTypes
{
	public class Cucumber : ProductOfNature
	{
		public Cucumber() : base("Cucumber", Kind.Fruit, MeasuringBy.PerItem, null)
		{

		}
	}
}