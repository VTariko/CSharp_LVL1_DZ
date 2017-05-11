using System;
using System.Collections.Generic;
using Helper;

namespace StudentsWork
{
	//Домашняя работа C#-1
	//Выполнил: Вячеслав Тарико (VTariko)
	//
	//3. Подсчитайте количество студентов:
	//	а) учащихся на 5 и 6 курсах;
	//	б)* подсчитайте сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся;
	//	в) отсортируйте список по возрасту студента
	//	г) * отсортируйте список по курсу и возрасту студента

	class StudentsWork
	{
		static void Main()
		{
			string path = "students_4.csv";
			TestStudentsDbClass(path);

			LogicHelper.Pause();
		}

		/// <summary>
		/// Тестирование класса базы данных студентов
		/// </summary>
		/// <param name="dbFile"></param>
		private static void TestStudentsDbClass(string dbFile)
		{
			//Инициализируем базу данных студентов
			StudentsDb students = new StudentsDb(dbFile);
			//Сортируем студентов по возрасту - слишком много данных для отображения, проверял через Debug
			students.SortByAge();
			//Сортируем студентов по курсу и возврасту - слишком много данных для отображения, проверял через Debug
			students.SortByCourseAndAge();
			LogicHelper.Line();
			Console.WriteLine("Учащихся на 5 курсе: {0}", students.StudentsOfTheFifth);
			Console.WriteLine("Учащихся на 6 курсе: {0}", students.StudentsOfTheSixth);
			LogicHelper.Line();
			//Создаем шаблон строки и выводим информацию по молодым студентам каждого курса
			string template = "Молодых студентов на {0} курсе: {1}";
			foreach (var youngCourse in students.YoungCourses)
			{
				Console.WriteLine(template, youngCourse.Key, youngCourse.Value);
			}
			LogicHelper.Line();
		}
	}
}
