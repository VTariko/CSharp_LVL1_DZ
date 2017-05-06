using System;
using Helper;

namespace DoublerGame
{
	class Doubler
	{
		#region Поля

		/// <summary>
		/// Текущее значение
		/// </summary>
		private int _current;

		/// <summary>
		/// Число, которое нужно достичь
		/// </summary>
		private int _finish;

		#endregion

		#region Свойства

		/// <summary>
		/// Возвращает текущее значение
		/// </summary>
		public int Current
		{
			get
			{
				return _current;
			}
		}

		/// <summary>
		/// Возвращает конечное значение
		/// </summary>
		public int Finish
		{
			get
			{
				return _finish;
			}
		}

		#endregion

		#region Конструктор

		/// <summary>
		/// Создание конечного числа
		/// </summary>
		/// <param name="max"></param>
		public Doubler(int max)
		{
			_current = 1;

			Random rand = new Random();
			_finish = rand.Next(1, max) + 1;
		}

		#endregion

		#region Методы

		/// <summary>
		/// Прибавить к текущему числу единицу
		/// </summary>
		public void AddOne()
		{
			_current++;
		}

		/// <summary>
		/// Умножить текущее число на два
		/// </summary>
		public void MultiTwo()
		{
			_current *= 2;
		}

		/// <summary>
		/// Сброс текущего числа до единицы
		/// </summary>
		public void ToOne()
		{
			_current = 1;
		}

		public void StartGame()
		{
			while (_current < _finish)
			{
				LogicHelper.Line();
				PrintReport();
				int select;
				CheckSelection(out select);
				switch (select)
				{
					case 1:
						AddOne();
						break;
					case 2:
						MultiTwo();
						break;
					case 3:
						ToOne();
						break;
				}
			}
			Console.WriteLine(Current > Finish ?
				"Текущее число вышло за пределы! Вы проиграли."
				: "Поздравляем! Вы выиграли!");
		}

		/// <summary>
		/// Вывод на печать информации по текущему состоянию игры.
		/// </summary>
		private void PrintReport()
		{
			Console.WriteLine("Надо получить:\t\t{0}\nТекущее значение:\t{1}", Finish, Current);
			Console.WriteLine("Выберите действие:\n{0}\n{1}\n{2}",
				"1 - Увеличить текущее число на 1",
				"2 - Умножить текущее число на 2",
				"3 - Сбросить текущее число до 1");
		}

		/// <summary>
		/// Проверка корректности выбранного действия
		/// </summary>
		/// <param name="select"></param>
		private void CheckSelection(out int select)
		{
			do
			{
				string str = Console.ReadLine();
				if (!int.TryParse(str, out select))
				{
					Console.WriteLine("Некорректный формат данных! Попробуйте еще раз.");
				}
				else
				{
					if (select > 3 || select < 1)
						Console.WriteLine("Введенное число вне допустимого диапазона! Попробуйте еще раз.");
					else
						break;
				}
			} while (true);
		}

		#endregion
	}
}
