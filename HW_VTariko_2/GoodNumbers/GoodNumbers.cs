﻿using System;
using Helper;

namespace GoodNumbers
{
	//Домашняя работа C#-1, Урок 1
	//Выполнил: Вячеслав Тарико (VTariko)
	//
	//Внимание! Решал задачи 5, 6 и 7.
	//
	//6. *Написать программу подсчета количества “Хороших” чисел в диапазоне от 1 до 1 000 000.
	//Хорошим называется число, которое делится на сумму своих цифр.Реализовать подсчет
	//времени выполнения программы, используя структуру DateTime.


	class GoodNumbers
	{
		static void Main(string[] args)
		{
			FindGoodNumber();
			LogicHelper.Pause();
		}

		#region Метод поиска количества хороших чисел (задача 6)

		/// <summary>
		/// Функция поиска "хороших" чисел. Полумолчанию, поиск идет от 1 до 1 000 000.
		/// Считаем время затрачиваемое на весь диапазон в целом.
		/// </summary>
		/// <param name="first">Первое число для интервала выборки</param>
		/// <param name="last">Последне число дял интервала выборки</param>
		private static void FindGoodNumber(int first = 1, int last = 1000000)
		{
			int count = 0;                          //Счетчик простых чисел - выставляем в ноль
			DateTime startLong = DateTime.Now;      //Запускаем таймер
			for (int i = first; i <= last; i++)     //Проходим по всем числам в заданном диапазоне
			{
				int sum = 0;                        //Сумма цифр - выставляем в ноль
				int a = i;                          //оперируем с числом a, чтобы не "повредить" наш "счетчик" цикла

				while (a > 0)                       //Будем находить последнюю цифру и отбрасывтаь ее от нашего числа до тех пор, пока не останется ноль.
				{
					sum += a % 10;                  //Остаток от деления числа на десять - это его крайняя цифра
					a /= 10;                        //Результат целочисленного делния на десять - это тоже самое число, без последней цифры
				}
				if (i % sum == 0)                   //Проверяем, делится ли без остатка наше число на сумму цифр
					count++;                        //Если да - у нас на одно "хорошее" число больше.
			}
			DateTime endLong = DateTime.Now;        //останавливаем атймер

			//Выводим на печать полученные результаты:
			Console.WriteLine(
				$"Количество \"хороших\" чисел в диапазоне от {first} до {last}: {count}\n" +
				$"Общие временные затраты: {(endLong - startLong).TotalMilliseconds:F2} мс");
		}

		#endregion
	}
}
