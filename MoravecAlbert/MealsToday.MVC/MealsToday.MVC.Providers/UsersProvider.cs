﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MealsToday.MVC.Providers.Assets;
using MealsToday.MVC.Providers.Base;
using MealsToday.MVC.Providers.Data;

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

		public User Insert(User user)
		{
			var sql = string.Format(SQL.User_Insert, user.UserTypeCode, user.FirstName, user.LastName, user.Email);

			ExecNonQuery();
			return Get()
		}

		public User Update(User user)
		{
			
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