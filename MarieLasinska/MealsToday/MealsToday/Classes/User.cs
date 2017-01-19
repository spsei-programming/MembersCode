using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealsToday.Enums;

namespace MealsToday.Classes
{
	class User
	{
		public int UserId { get; set; }

		public string Username { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string FullName
		{
			get {return FirstName + " " + LastName; }
		}

		public string ReverseFullName
		{
			get {return LastName + " " + FirstName; }
		}

		public Roles Role { get; set; }
	}
}
