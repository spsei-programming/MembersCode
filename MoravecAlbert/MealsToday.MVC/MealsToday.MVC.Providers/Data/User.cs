using System.Runtime.InteropServices;

namespace MealsToday.MVC.Providers.Data
{
	public class User
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserTypeCode { get; set; }
		public string FullName => $"{LastName}, {FirstName}";
	}
}