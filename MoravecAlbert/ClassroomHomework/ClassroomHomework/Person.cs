namespace ClassroomHomework
{
	public class Person
	{
		public enum Genders
		{
			Male,
			Female
		};

		public string Name;
		public int Age;
		public Genders Gender;

		public Person(string name, int age, Genders gender)
		{
			Name = name;
			Age = age;
			Gender = gender;
		}
	}
}