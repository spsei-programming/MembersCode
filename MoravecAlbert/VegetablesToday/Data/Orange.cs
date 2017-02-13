using Data.Base;
using Data.Enums;

namespace Data
{
	public class Orange : ProductOfNature
	{
		public Orange() : base("Orange", Kinds.Fruit, Measurings.PerWeight, WeightUnits.Kilogram)
		{

		}
	}
}