﻿using System;
using Helper;

namespace ArrayByThree
{
	//Домашняя работа C#-1, Урок 4
	//Выполнил: Вячеслав Тарико (VTariko)
	//
	//1.	Дан целочисленный массив из 20 элементов.Элементы массива могут принимать целые
	//значения от –10 000 до 10 000 включительно.Написать программу, позволяющую найти и вывести
	//количество пар элементов массива, в которых хотя бы одно число делится на 3. В данной задаче
	//под парой подразумевается два подряд идущих элемента массива.

	class ArrayByThree
	{
		static void Main(string[] args)
		{
			//Создаем и заполняем архив
			int[] array = GenerateArray(20);

			//Вывордим полученный массив на кэран:
			Console.WriteLine("Полученный массив: {0}", string.Join(", ", array));

			//Ищем и вывоим на экран количество пар, делимых на значение по умочланию (в нашем случае - 3)
			Console.WriteLine("Количество пар в массиве, в которых хотя бы одно число делится на 3: {0}",
				ScanArrayForThree(array));
			
			//Задаем константу-делитель
			const int div = 4;
			//Ищем и вывоим на экран количество пар, делимых на выбранную константу
			Console.WriteLine("Количество пар в массиве, в которых хотя бы одно число делится на {1}: {0}",
				ScanArrayForThree(array, div), div);

			LogicHelper.Pause();
		}

		#region Создание массива

		/// <summary>
		/// Метод создает и заполняет массив случайными числами в заданном диапазоне
		/// </summary>
		/// <param name="size">Размер создаваемого массива</param>
		/// <param name="min">Минимальное допустимое значение в массиве</param>
		/// <param name="max">Максимальное допустимое значение в массиве</param>
		/// <returns>Массив длины size, случайно заполненный значениями от min до max</returns>
		private static int[] GenerateArray(int size, int min = -10000, int max = 10000)
		{
			//Создаем массив
			int[] array = new int[size];

			//Меняем местами, если введенный минимум больше введенного максимума
			if (min > max)
			{
				int t = min;
				min = max;
				max = t;
			}

			Random rand = new Random();
			//Каждый элемент массива - случайное число в диапазоне от min до max
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = rand.Next(min, max);
			}

			return array;
		}

		#endregion

		#region Поиск делимых пар

		/// <summary>
		/// Сканирование пар массива на то, делится ли в ней хотя бы один элемент на заданный делитель
		/// </summary>
		/// <param name="array">Массив ,в котором производится поиск</param>
		/// <param name="div">Делитель</param>
		/// <returns>Количество пар в массиве, кратных делителю</returns>
		private static int ScanArrayForThree(int[] array, int div = 3)
		{
			//Создаем счетчик пар - изначально ноль
			int count = 0;

			//Идем по массиву, кроме последнего жлемента - у него нет пары
			for (int i = 0; i < array.Length - 1; i++)
			{
				//Если текущий элемент или следующий за ним кратны делителю DIV - увеличиваем счетчик на единицу
				if (array[i] % div == 0 || array[i + 1] % div == 0)
				{
					count++;
				}
			}

			//Возвращаем счетчик
			return count;
		}

		#endregion
	}
}
