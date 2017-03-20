using System;
using System.Data.SqlClient;

namespace MealsToday.MVC.Providers.Base
{
	public abstract class GenericDataBaseProvider<T> : BaseDatabaseProvider
	{
		protected abstract T SelectMapFunction(SqlDataReader reader);
	}
}