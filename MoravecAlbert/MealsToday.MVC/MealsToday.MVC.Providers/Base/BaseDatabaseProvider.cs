using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MealsToday.MVC.Providers.Base
{
	public abstract class BaseDatabaseProvider
	{
		protected void Exec(string sql, Action<SqlCommand> what)
		{
			var connectionString = ConfigurationManager.ConnectionStrings["MealsDB"].ConnectionString;

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				SqlCommand cmd = conn.CreateCommand();

				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;

				conn.Open();

				what(cmd);

				conn.Close();
			}
		}

		protected void ExecNonQuery(string sql)
		{
			Exec(sql, cmd => cmd.ExecuteNonQuery());
		}

		protected List<T> ExecuteQuery<T>(string sql, Func<SqlDataReader, T> mapFunc, CommandBehavior? behavior = null)
		{
			List<T> list = new List<T>(50);

			Exec(sql, cmd =>
			{
				using (var reader = cmd.ExecuteReader(behavior ?? CommandBehavior.Default))
				{
					if (reader.HasRows)
						while (reader.Read())
						{
							list.Add(mapFunc(reader));
						}
				}
			});

			return list;
		}

		protected T ExecuteSingleQuery<T>(string sql, Func<SqlDataReader, T> mapFunc)
		{
			return ExecuteQuery(sql, mapFunc, CommandBehavior.SingleRow).FirstOrDefault();
		}
	}
}