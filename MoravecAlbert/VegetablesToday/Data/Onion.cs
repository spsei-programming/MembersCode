using System.Runtime.CompilerServices;
using Data.Base;
using Data.Enums;

namespace Data
{
	public class Onion : ProductOfNature
	{
		public Onion() : base("Onion", Kinds.Vegetable, Measurings.PerWeight, WeightUnits.Ton)
		{

		}
	}
}