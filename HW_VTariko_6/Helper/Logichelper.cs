using System;

namespace Helper
{
	//Домашняя работа C#-1
	//Выполнил: Вячеслав Тарико (VTariko)


	/// <summary>
	/// Класс вспомогательных методов
	/// </summary>
	public static class LogicHelper
    {
		/// <summary>
		/// Метод вывод на экран линию-разделитель, состоящую из 40 знаков '-'
		/// </summary>
		public static void Line()
	    {
		    Console.WriteLine(new string('-', 40));
	    }

	    /// <summary>
	    /// Метод ожидания ввода
	    /// </summary>
	    public static void Pause()
	    {
		    Console.WriteLine("Нажмите Enter для продолжения...");
		    Console.ReadKey();
	    }

		/// <summary>
		/// Наименьшее общее кратное
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static int Nok(int a, int b)
		{
			return Math.Abs(a * b) / Nod(a, b);
		}

		/// <summary>
		/// Наибольший общий делитель
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static int Nod(int a, int b)
		{
			while (b != 0)
			{
				int t = a % b;
				a = b;
				b = t;
			}
			return a;
		}
	}
}
