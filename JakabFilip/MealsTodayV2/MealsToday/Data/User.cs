using System.Collections.Generic;
using MealsToday.Enums;

namespace MealsToday.Data
{
	public class User
	{
		public int UserId { get; set; }
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public List<UserRoles> Roles { get; } = new List<UserRoles>(5);

		public string FullName
		{
			get { return FirstName + " " + LastName; }
		}

		public string ReversedFullName
		{
			get { return LastName + " " + FirstName; }
		}
	}
}