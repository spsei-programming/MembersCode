using Data.Base;
using Data.Enums;

namespace Data
{
	public class Kiwi : ProductOfNature
	{
		public Kiwi() : base("Kiwi", Kinds.Fruit, Measurings.PerWeight, WeightUnits.Gram)
		{

		}
	}
}