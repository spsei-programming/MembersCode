using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace MVCForms.Providers
{
	public class DataBaseProvider
	{
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
				cmd.CommandText = $"insert into Allergen(Name, Number)" +
				                  $"values('{name}', '{number}')";
				cmd.CommandType = CommandType.Text;

				connection.Open();
				cmd.ExecuteNonQuery();
				connection.Close();
			}
		}
	}
}