using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MealsToday.MVC.Providers.Assets;
using MealsToday.MVC.Providers.Base;
using MealsToday.MVC.Providers.Data;
using MealsToday.MVC.Providers.DbModels;

namespace MealsToday.MVC.Providers
{
	public class UsersProvider : GenericDatabaseProvider<User>
	{
		public User Get(int id)
		{
			var sql = $"{SQL.User_BaseSelect} WHERE UserId = {id}";

			return ExecuteSingleQuery(sql, SelectMapFunction);
		}

		public List<User> GetList(string condition)
		{
			var sql = $"{SQL.User_BaseSelect} WHERE {condition}";

			return ExecuteQuery(sql, SelectMapFunction);
		}

		public int Insert(User user)
		{
			var sql = string.Format(SQL.User_Insert, user.UserTypeCode, user.FirstName, user.LastName, user.Email);

			var model = ExecuteSingleQuery(sql,
				reader => new UserInserted() {Email = reader["Email"].ToString(), UserId = (int) reader["UserId"]});
			return model.UserId;
		}

		public User Update(User user)
		{
			var connectionString = ConfigurationManager.ConnectionStrings["MealsDB"].ConnectionString;

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				SqlCommand cmd = conn.CreateCommand();

				cmd.CommandText = "dbo.UpdateUser";
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("firstName", user.FirstName);
				cmd.Parameters.AddWithValue("lastName", user.LastName);
				cmd.Parameters.AddWithValue("email", user.Email);
				cmd.Parameters.AddWithValue("usertypecode", user.UserTypeCode);
				cmd.Parameters.AddWithValue("userid", user.Id);

				conn.Open();

				cmd.ExecuteNonQuery();

				conn.Close();
			}
		}

		public void Delete(int id)
		{
			
		}

		protected override User SelectMapFunction(SqlDataReader reader)
		{
			User usr = new User
			{
				Id = (int) reader["UserId"],
				FirstName = reader["FirstName"] as string,
				LastName = reader["LastName"] as string,
				Email = reader["Email"] as string,
				UserTypeCode = reader["UserTypeCode"] as string
			};


			return usr;
		}
	}
}