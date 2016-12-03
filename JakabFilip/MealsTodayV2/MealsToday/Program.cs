using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealsToday.Data;
using MealsToday.Helpers;

namespace MealsToday
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var users = CSVLoader.LoadUserData(@"");
			Context.AllUsers = users;
			LogIn();
		}

		public static void LogIn()
		{
			Console.Write("Username: ");
			var username = Console.ReadLine();
			Console.Write("Password: ");
			var password = Console.ReadLine();

			foreach (var user in Context.AllUsers)
			{
				if (!user.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) || user.Password != password) continue;
				Console.WriteLine("Ur now logged in.");
				Context.CurrentUser = user;
				return;
			}

			throw new UnauthorizedAccessException();
		}
	}
}
