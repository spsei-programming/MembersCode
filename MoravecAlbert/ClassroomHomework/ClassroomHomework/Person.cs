namespace ClassroomHomework
{
	public class Person
	{
		public enum Genders
		{
			Male,
			Female
		};

		public string FirstName;
		public string LastName;
		public int Age;
		public Genders Gender;

		public Person(string firstName, string lastName, int age, Genders gender)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;
			Gender = gender;
		}
	}
}