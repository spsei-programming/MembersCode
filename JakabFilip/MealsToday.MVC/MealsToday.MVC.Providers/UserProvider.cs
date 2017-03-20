using System.Collections.Generic;
using System.Data.SqlClient;
using MealsToday.MVC.Providers.Assets;
using MealsToday.MVC.Providers.Base;
using MealsToday.MVC.Providers.Data;

namespace MealsToday.MVC.Providers
{
	public class UserProvider : GenericDataBaseProvider<User>
	{
		public User Get(int id)
		{
			var sql = $"{string.Format(SQL.User_BaseSelect)} where userid = {id}";
			return ExecuteSingleQuery(sql, SelectMapFunction);
		}

		public List<User> GetList(string condition = "")
		{
			var sql = $"{string.Format(SQL.User_BaseSelect)} where {condition}";
			return ExecuteQuery(sql, SelectMapFunction);
		}

		public User Insert(User user)
		{
			var sql = string.Format(SQL.User_Instert, user.UserTypeCode, user.FirstName, user.LastName, user.Email);

			ExecNonQuery(sql);
		}

		public User Update(User user)
		{
			
		}

		public User Delete(User user)
		{
			
		}

		protected override User SelectMapFunction(SqlDataReader reader)
		{
			var user = new User
			{
				Id = (int)reader["UserId"],
				FirstName = reader["FirstName"] as string,
				LastName = reader["LastName"] as string,
				Email = reader["Email"] as string,
				UserTypeCode = reader["UserTypeCode"] as string
			};

			return user;
		}
	}
}