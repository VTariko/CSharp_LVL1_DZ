using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SchoolTask
{
	class StudentsDb
	{
		#region Поля

		/// <summary>
		/// Список студентов
		/// </summary>
		private Student[] _students;

		#endregion

		#region Свойства

		/// <summary>
		/// Количество сутдентов
		/// </summary>
		public int Count { get; private set; }

		#endregion

		#region Конструкторы

		public StudentsDb()
		{
			//Узнаем количество студентов
			AskCount();
			//Инициализируем массив студентов
			_students = new Student[Count];
			//Заполняем данные по студентам
			AskStudents();
		}

		#endregion

		#region Методы

		/// <summary>
		/// Внутренний метод, чтобы узнать количество студентов
		/// </summary>
		private void AskCount()
		{
			Console.WriteLine("Сколько студентов обучается в выбранной школе? (от 10 до 100)\t");
			int count = 0;
			bool flag = false;
			while (!flag)
			{
				try
				{
					string str = Console.ReadLine();
					if (!int.TryParse(str, out count))
						throw new Exception("Некорректный формат данных!");
					if (count < 5 || count > 100)
						throw new Exception("Введенное число вне допустимого диапазона!");
					flag = true;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			//Сохраняем в свойство поулченное число студентов
			Count = count;
		}

		/// <summary>
		/// Внутренний метод, чтобы ввести данные по всем студентам
		/// </summary>
		private void AskStudents()
		{
			string pattern = @"^\w{2,20}\s\w{2,15}\s([2-5]\s){2}[2-5]$";
			Regex regex = new Regex(pattern);

			for (int i = 0; i < Count; i++)
			{
				Console.WriteLine("Введите данные о студенте {0} в формате <Фамилия> <Имя> <оценки>:", i + 1);

				bool flag = false;
				while (!flag)
				{
					try
					{
						string studentInfo = Console.ReadLine();

						if (studentInfo == null || !regex.IsMatch(studentInfo))
							throw new Exception("Некорректный формат данных!");

						//Парсим введенную по шаблону строку и формируем из нее студента:
						string[] student = studentInfo.Split(' ');
						_students[i] = new Student(student[0], student[1], int.Parse(student[2]), int.Parse(student[3]),
							int.Parse(student[4]));
						
						flag = true;
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
					
				}
			}
		}

		public string BadStudents()
		{
			//Для начала сортируем список студентов
			Array.Sort(_students);
			//Создает List для хранения данных о плохих студентов
			List<Student> badList = new List<Student>();
			//Запоминаем в список первых трех студентов, у которых самый низкий балл
			badList.Add(_students[0]);
			badList.Add(_students[1]);
			badList.Add(_students[2]);
			//Дальше идем по списку студентов до тех пор, пока средний балл совпадает со средним баллом третьего (крайнего) студента
			for (int i = 3; i < _students.Length; i++)
			{
				if (Math.Abs(_students[i].Average - _students[2].Average) < 0.01)
					badList.Add(_students[i]);
				else
					break;
			}
			//Возвращаем строку-список худших студентов
			return string.Join(",\n", badList);
		}

		#endregion
	}
}
