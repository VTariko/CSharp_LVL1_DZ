using System;
using System.Collections;
using System.Linq;

namespace SchoolTask
{
	class Student : IComparable
	{
		#region Свойства

		/// <summary>
		/// Фамилия студента
		/// </summary>
		public string Surname { get; set; }

		/// <summary>
		/// Имя студента
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Оценки студента
		/// </summary>
		public int[] Scores { get; set; }

		/// <summary>
		/// Средний балл студента
		/// </summary>
		public double Average => Scores.Average();

		#endregion

		#region Конструкторы

		/// <summary>
		/// Создает объект класса
		/// </summary>
		/// <param name="surname">Фамилия студента</param>
		/// <param name="name">Имя студента</param>
		/// <param name="scores">Оценки студента</param>
		public Student(string surname, string name, params int[] scores)
		{
			Surname = surname;
			Name = name;
			Scores = scores;
		}

		#endregion

		#region Методы

		/// <summary>
		/// Возвращает строковое представление текущего объекта
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("{0} {1}", Surname, Name);
		}

		public int CompareTo(object obj)
		{
			Student studentY = (Student) obj;

			return this.Average > studentY.Average ? 1 : Math.Abs(this.Average - studentY.Average) < 0.01 ? 0 : -1;
		}

		#endregion
	}
}
