using System;

namespace Helper
{
	//Домашняя работа C#-1, Урок 1
	//Выполнил: Вячеслав Тарико (VTariko)
	//
	//Внимание! Решал задачи 5, 6 и 7.


	/// <summary>
	/// Класс вспомогательных методов
	/// </summary>
	public class LogicHelper
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
    }
}
