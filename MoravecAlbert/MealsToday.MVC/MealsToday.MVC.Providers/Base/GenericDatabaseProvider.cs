using System;
using System.Data.SqlClient;

namespace MealsToday.MVC.Providers.Base
{
	public abstract class GenericDatabaseProvider<T> : BaseDatabaseProvider
	{
		protected abstract T SelectMapFunction(SqlDataReader reader);
	}
}