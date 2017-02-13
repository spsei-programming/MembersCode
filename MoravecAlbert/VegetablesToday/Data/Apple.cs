using Data.Base;
using Data.Enums;

namespace Data
{
	public class Apple : ProductOfNature
	{
		public Apple() : base("Apple", Kinds.Fruit, Measurings.PerWeight, WeightUnits.Kilogram)
		{
			
		}
	}
}