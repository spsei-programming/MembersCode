using System;
using VegetablesToday.Data.Base;
using VegetablesToday.Data.Enums;

namespace VegetablesToday.Data
{
	public class Pineapple : ProductOfNature
	{
		public Pineapple() : base("Pineapple", Kind.Fruit, MeasuringBy.PerItem, null)
		{
			
		}
	}
}