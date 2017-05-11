namespace StudentsWork
{
	/// <summary>
	/// Класс студента
	/// </summary>
	class Student
	{
		#region Свойства

		/// <summary>
		/// Имя студента
		/// </summary>
		public string FirstName { get; }

		/// <summary>
		/// Фамилия студента
		/// </summary>
		public string SecondName { get; }

		/// <summary>
		/// Наименование университета
		/// </summary>
		public string Univercity { get; }

		/// <summary>
		/// Наименование факультета
		/// </summary>
		public string Faculty { get; }

		/// <summary>
		/// Наименование кафедры
		/// </summary>
		public string Department { get; }

		/// <summary>
		/// Возраст студента
		/// </summary>
		public byte Age { get; }

		/// <summary>
		/// Номер курса
		/// </summary>
		public byte Course { get; }

		/// <summary>
		/// Номер группы
		/// </summary>
		public byte Group { get; }

		/// <summary>
		/// Название города студента
		/// </summary>
		public string City { get; }

		#endregion

		#region Конструкторы

		/// <summary>
		/// Созданет объект Студента - все поля заполняются вручную
		/// </summary>
		/// <param name="firstName">Имя студента</param>
		/// <param name="secondName">Фамилия студента</param>
		/// <param name="univercity">Наименование университета</param>
		/// <param name="faculty">Наименование факультета</param>
		/// <param name="department">Наименование кафедры</param>
		/// <param name="age">Возраст студента</param>
		/// <param name="course">Номер курса</param>
		/// <param name="group">Номер группы</param>
		/// <param name="city">Название города студента</param>
		public Student(string firstName, string secondName, string univercity, string faculty, string department, byte age, byte course, byte group, string city)
		{
			FirstName = firstName;
			SecondName = secondName;
			Univercity = univercity;
			Faculty = faculty;
			Department = department;
			Age = age;
			Course = course;
			Group = group;
			City = city;
		}

		#endregion

		#region Методы

		/// <summary>
		/// Сравнение двух студентов по возрасту
		/// </summary>
		/// <param name="st1">Первый студент</param>
		/// <param name="st2">Второй студент</param>
		/// <returns></returns>
		public static int CompareByAge(Student st1, Student st2)
		{
			return st1.Age > st2.Age ? 1 : st1.Age == st2.Age ? 0 : -1;
		}

		/// <summary>
		/// Сравнение двух студентов по курсу и возрасту
		/// </summary>
		/// <param name="st1">Первый студент</param>
		/// <param name="st2">Второй студент</param>
		/// <returns></returns>
		public static int CompareByCourseAndAge(Student st1, Student st2)
		{
			return st1.Course > st2.Course ? 1 : st1.Age < st2.Age ? -1 : st1.Age > st2.Age ? 1 : st1.Age == st2.Age ? 0 : -1;
		}

		#endregion
	}
}
