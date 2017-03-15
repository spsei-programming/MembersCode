using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using MVCForms.Providers.Data;

namespace MVCForms.Providers
{
	public class DataBaseProvider
	{
		protected void Exec(string sql, Action<SqlCommand> what)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["MealsDB"].ConnectionString;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand
				{
					Connection = connection,
					CommandText = sql,
					CommandType = CommandType.Text
				};
				connection.Open();

				what(cmd);

				connection.Close();
			}
		}

		protected void ExecNonQuery(string sql)
		{
			Exec(sql, cmd =>
			{
				cmd.ExecuteNonQuery();
			});
		}

		protected void ExecQuery(string sql)
		{
			Exec(sql, cmd =>
			{

			});
		}

		public void CreateAllergen(string name, byte number)
		{
			// 1. create sql connetion
			// 2. create sql command
			// 3. Read data if necessary or required 

			string connectionString = ConfigurationManager.ConnectionStrings["MealsDB"].ConnectionString;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand cmd = connection.CreateCommand();
				cmd.Connection = connection;
				cmd.CommandText = "insert into Allergen(Name, Number)" +
													$"values('{name}', '{number}')";
				cmd.CommandType = CommandType.Text;

				connection.Open();
				cmd.ExecuteNonQuery();
				connection.Close();
			}
		}

		public List<Allergen> GetAllergens()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["MealsDB"].ConnectionString;

			List<Allergen> allergens = new List<Allergen>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand
				{
					Connection = connection,
					CommandText = "SELECT *" +
												"FROM Allergens;"
				};
				connection.Open();
				using (SqlDataReader dataReader = cmd.ExecuteReader())
				{
					while (dataReader.NextResult())
					{
						allergens.Add(new Allergen
						{
							Name = dataReader["Name"] as string,
							AllergenId = Convert.ToInt16(dataReader["AllergenId"]),
							Number = Convert.ToByte(dataReader["Number"])
						});
					}
				}
				connection.Close();
			}

			return allergens;
		}

		public void DeleteAllergen(int id)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["MealsDB"].ConnectionString;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand
				{
					Connection = connection,
					CommandText = "DELETE" +
												"FROM Allergens" +
												$"WHERE AllergenId = {id}"
				};

				connection.Open();

				cmd.ExecuteNonQuery();

				connection.Close();
			}
		}
	}
}