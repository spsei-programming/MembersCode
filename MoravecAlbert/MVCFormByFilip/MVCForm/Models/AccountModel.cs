using System;
using MVCForm.Models.Enums;

namespace MVCForm.Models
{
	public class AccountModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public UserTypes UserType { get; set; }
		public DateTime Birthday { get; set; }
	}
}