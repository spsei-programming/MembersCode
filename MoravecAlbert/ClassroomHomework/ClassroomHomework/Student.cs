namespace ClassroomHomework
{
	public class Student : Person
	{
		public enum Fields
		{
			InformationTechnologies,
			ElectricalEngineering
		};

		public enum Specializations
		{
			Programming,
			Networking,
			MicrocontrollerApplication,
			Electroenergetics
		};

		public Fields Field;
		public Specializations Specialization;
		public Subject FavouriteSubject;
		public bool IsInLesson; //possibly unecessary field as we can check against HasLesson (HasLesson != null (?))
		public Subject HasLesson;

		public Student(string name, int age, Genders gender, Fields field, Specializations spec, Subject favsub)
			: base(name, age, gender)
		{
			Field = field;
			Specialization = spec;
			FavouriteSubject = favsub;
		}

		public void LeaveLesson()
		{
			IsInLesson = false;
			HasLesson = null;
		}
	}
}