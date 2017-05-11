using System;
using System.Collections.Generic;
using System.IO;

namespace StudentsWork
{
	/// <summary>
	/// Класс хранения базы студентов
	/// </summary>
	class StudentsDb
	{
		#region Поля

		/// <summary>
		/// Список студентов
		/// </summary>
		private List<Student> _students;

		/// <summary>
		/// Словарь для хранения информации, сколько на каком курсе учится студентов
		/// </summary>
		private Dictionary<byte, int> _allStudentsCourse;

		#endregion

		#region Свойства

		/// <summary>
		/// Словарь для хранения информации, сколько на каком курсе учится студентов в возрасте 18-20 лет.
		/// Ключ - курс, значение - количество молодых студентов.
		/// </summary>
		public Dictionary<byte, int> YoungCourses { get; private set; }

		/// <summary>
		/// Количество учащихся первого курса
		/// </summary>
		public int StudentsOfTheFirst => _allStudentsCourse[1];

		/// <summary>
		/// Количество учащихся второго курса
		/// </summary>
		public int StudentsOfTheSecond => _allStudentsCourse[2];

		/// <summary>
		/// Количество учащихся третьего курса
		/// </summary>
		public int StudentsOfTheThird => _allStudentsCourse[3];

		/// <summary>
		/// Количество учащихся четвертого курса
		/// </summary>
		public int StudentsOfTheFourth => _allStudentsCourse[4];

		/// <summary>
		/// Количество учащихся пятого курса
		/// </summary>
		public int StudentsOfTheFifth => _allStudentsCourse[5];

		/// <summary>
		/// Количество учащихся шестого курса
		/// </summary>
		public int StudentsOfTheSixth => _allStudentsCourse[6];

		#endregion

		#region Конструкторы

		public StudentsDb(string pathFile)
		{
			if (File.Exists(pathFile))
			{
				//Инициализируем базовые коллекции - список студентов, всех учащихся и их курсов, а так же молодых учащихся и их курсов
				_students = new List<Student>();
				_allStudentsCourse = new Dictionary<byte, int>
				{
					{1, new int()},
					{2, new int()},
					{3, new int()},
					{4, new int()},
					{5, new int()},
					{6, new int()}
				};
				YoungCourses = new Dictionary<byte, int>
				{
					{1, new int()},
					{2, new int()},
					{3, new int()},
					{4, new int()},
					{5, new int()},
					{6, new int()}
				};

				using (StreamReader sr = new StreamReader(pathFile))
				{
					while (!sr.EndOfStream)
					{
						try
						{
							string line = sr.ReadLine();
							if (line != null)
							{
								string[] s = line.Split(';');
								byte course = byte.Parse(s[6]);
								_students.Add(new Student(s[0], s[1], s[2], s[3], s[4], byte.Parse(s[5]), course, byte.Parse(s[7]),
									s[8]));
								//Добавляем к количеству соответствующего курса еще одного студента
								_allStudentsCourse[course]++;
								//Если студент - "молодой", прибавляем к соответсвующему курсу еще одного учащегося.
								if (byte.Parse(s[5]) >= 18 && byte.Parse(s[5]) <= 20)
								{
									YoungCourses[course]++;
								}
							}
						}
						catch (Exception ex)
						{
							throw new Exception("Ошибка форматирования файла!", ex);
						}
					}
				}
			}
			else
			{
				throw new FileNotFoundException("Указанного файла не существует!");
			}
		}

		#endregion

		#region Методы

		/// <summary>
		/// Сортировка студентов по возрасту
		/// </summary>
		public void SortByAge()
		{
			_students.Sort(new Comparison<Student>(Student.CompareByAge));
		}

		/// <summary>
		/// Сортировка студентов по курсу и возрасту
		/// </summary>
		public void SortByCourseAndAge()
		{
			//Используем вызов делегата в сокращенном виде - "набиваем руку"
			_students.Sort(Student.CompareByCourseAndAge);
		}

		#endregion
	}
}
