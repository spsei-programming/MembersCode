using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealsToday.MVC.Providers.Base;
using MealsToday.MVC.Providers.Data;

namespace MealsToday.MVC.Providers
{
	public class AllergenProvider : BaseDatabaseProvider
	{
		
		public void CreateAllergen(string name, byte number)
		{
			// 1. Create SQL connection
			// 2. Create SQL command 
			// 3. Read data if necessary or required with Sql reader or data provider
			var sql = $"insert into Allergen(Name, Number) " + $"values ('{name}', {number})";
			ExecNonQuery(sql);

			#region Not according to DRY principle

			//var connectionString = ConfigurationManager.ConnectionStrings["MealsDB"].ConnectionString;

			//using (SqlConnection conn = new SqlConnection(connectionString))
			//{
			//	SqlCommand cmd = conn.CreateCommand();

			//	cmd.CommandText = $"insert into Allergen(Name, Number) " +
			//										$"values ('{name}', {number})";
			//	cmd.CommandType = CommandType.Text;

			//	conn.Open();
			//	cmd.ExecuteNonQuery();
			//	conn.Close();
			//}

			#endregion
		}

		public List<Allergen> GetAllergens()
		{
			var sql = $"select * from Allergen";
			return ExecuteQuery(sql, reader =>
			{
				Allergen al;
				al.Name = reader["Name"] as string;
				//if (reader["Name"] is string) al.Name = (string) reader["Name"];
				al.Number = Convert.ToByte(reader["Number"]);
				al.AllergenId = Convert.ToInt16(reader["AllergenId"]);
				return al;
			});

			#region Not according to DRY principle

			//var connectionString = ConfigurationManager.ConnectionStrings["MealsDB"].ConnectionString;

			//using (SqlConnection conn = new SqlConnection(connectionString))
			//{
			//	SqlCommand cmd = conn.CreateCommand();

			//	cmd.CommandText = 
			//	cmd.CommandType = CommandType.Text;

			//	conn.Open();

			//	List<Allergen> allergens = new List<Allergen>();

			//	using (var reader = cmd.ExecuteReader())
			//	{
			//		if (reader.HasRows)
			//			while (reader.Read())
			//			{
			//				Allergen al;
			//				al.Name = reader["Name"] as string;
			//				//if (reader["Name"] is string) al.Name = (string) reader["Name"];
			//				al.Number = Convert.ToByte(reader["Number"]);
			//				al.AllergenId = Convert.ToInt16(reader["AllergenId"]);

			//				allergens.Add(al);
			//			}
			//	}

			//	conn.Close();

			//	return allergens;
			//}

			#endregion
		}

		public Allergen GetAllergen(short allergenId)
		{
			string sql = $"select AllergenId, Name, Number from dbo.Allergen where AllergenId = {allergenId}";

			return ExecuteSingleQuery(sql, reader =>
			{
				Allergen al;
				al.Name = reader["Name"] as string;
				al.Number = Convert.ToByte(reader["Number"]);
				al.AllergenId = Convert.ToInt16(reader["AllergenId"]);

				return al;
			});

			#region Not according to DRY principle

			var connectionString = ConfigurationManager.ConnectionStrings["MealsDB"].ConnectionString;

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				SqlCommand cmd = conn.CreateCommand();

				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;

				conn.Open();

				List<Allergen> allergens = new List<Allergen>();

				using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow | CommandBehavior.CloseConnection))
				{
					if (reader.HasRows)
						while (reader.Read())
						{
							Allergen al;
							al.Name = reader["Name"] as string;
							al.Number = Convert.ToByte(reader["Number"]);
							al.AllergenId = Convert.ToInt16(reader["AllergenId"]);

							return al;
						}
				}


			}
			throw new ArgumentOutOfRangeException(nameof(allergenId), $"Could not find an allergen with Id: {allergenId}");

			#endregion
		}

		public Allergen UpdateAllergen(short allergenId, byte? number, string name)
		{
			string sql = "update dbo.Allergen set ";

			if (number != null)
				sql += $"number = {number},";
			if (!string.IsNullOrEmpty(name))
				sql += $"name = '{name}',";

			sql = sql.TrimEnd(',');

			sql += $" where allergenId = {allergenId}";

			ExecNonQuery(sql);

			#region Not according to DRY principle

			//var connectionString = ConfigurationManager.ConnectionStrings["MealsDB"].ConnectionString;

			//using (SqlConnection conn = new SqlConnection(connectionString))
			//{
			//	SqlCommand cmd = conn.CreateCommand();

			//	cmd.CommandText = sql;
			//	cmd.CommandType = CommandType.Text;

			//	conn.Open();
			//	cmd.ExecuteNonQuery();
			//	conn.Close();
			//}

			#endregion
			return GetAllergen(allergenId);
		}

		public Allergen UpdateAllergen(short allergenId, byte number)
		{
			return UpdateAllergen(allergenId, number, string.Empty);
		}

		public Allergen UpdateAllergen(short allergenId, string name)
		{
			return UpdateAllergen(allergenId, null, name);
		}

		public void DeleteAllergen(short allergenId)
		{
			string sql = $"delete from Allergen where AllergenId = {allergenId}";

			var connectionString = ConfigurationManager.ConnectionStrings["MealsDB"].ConnectionString;

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				SqlCommand cmd = conn.CreateCommand();

				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;

				conn.Open();

				cmd.ExecuteNonQuery();

				conn.Close();
			}
		}
	}
}
