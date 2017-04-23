﻿using System;
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices;

namespace Console_App_2
{
	class Program
	{
		//Домашняя работа C#-1, Урок 1
		//Выполнил: Вячеслав Тарико (VTariko)
		//
		//Внимание! Решал задачи 5, 6 и 7.
		//
		//5.	а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс
		//массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;
		//		б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
		//6. *Написать программу подсчета количества “Хороших” чисел в диапазоне от 1 до 1 000 000.
		//Хорошим называется число, которое делится на сумму своих цифр.Реализовать подсчет
		//времени выполнения программы, используя структуру DateTime.
		//7.	a) Разработать рекурсивный метод, который выводит на экран числа от a до b;
		//		б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.


		#region Классы

		/// <summary>
		/// Класс вспомогательных методов
		/// </summary>
		static class Helper
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

		#endregion

		static void Main()
		{
			RecursePrint(1, 6);				//Вывод на печать чисел от a=1 до b=6
			Helper.Line();					//Проводим линию-разделитель
			int summ = RecurseSumm(1, 9);   //Считаем сумму чисел от a=1 до b=9
			Console.WriteLine(summ);		//Выводим полученную сумму на экран
			Helper.Line();                  //Проводим линию-разделитель
			FindGoodNumber();				//Ищем количество "хороших" чисел от 1 до 1 000 000
			Helper.Line();                  //Проводим линию-разделитель
			Helper.Pause();					//Ожидаем ввода с клавиатуры
			MassHeight();					//Запрашиваем массу и рост человека и выводим результаты вычисления Индекса Массы Тела с заключением
			Helper.Pause();					//Ожидаем ввода с клавиатуры перед завершением программы
		}

		#region Методы

		#region Индекс Массы Тела (задача 5)

		#region Запрос массы и веса для вычиесления Индекса Массы Тела

		/// <summary>
		/// Функция запрашивает рост и массу тела человека и передает эти данные для вычесления ИМТ
		/// </summary>
		static void MassHeight()
		{
			double weight, height;

			//Проверка роста на валидность
			do
			{
				Console.Write("Введите свой рост, м:");
			} while (!double.TryParse(Console.ReadLine(), out height) && height <= 0);

			//Проверка массы на валидность
			do
			{
				Console.Write("Введите свой вес, кг:");
			} while (!double.TryParse(Console.ReadLine(), out weight) && weight <= 0);

			BodyMassIndex(weight, height);				//Передаем полученные массу и рост для вычисления Индекса массы тела
		}

		#endregion

		#region Метод вычесления индекса массы тела

		/// <summary>
		/// Функция вычисления индекса массы тела
		/// </summary>
		/// <param name="w">Масса тела испытуемого</param>
		/// <param name="h">Рост тела испытуемого</param>
		static void BodyMassIndex(double w, double h)
		{
			bool isNormal = false;									//Заводим переменную ,которая скажет нам,
																	//в норме ли наш пациент и если нет - отправит результаты на расчет
			double bmi = w / (h * h);                               //Подсчет индекса массы тела
			string res;												//Переменная для интерпритации результатов
			if (bmi <= 16)
			{
				res = "Выраженный дефицит массы тела";
			}
			else if (bmi <= 18.5)
			{
				res = "Недостаточная (дефицит) масса тела";
			}
			else if (bmi < 25)
			{
				res = "Норма";
				isNormal = true;
			}
			else if (bmi <= 35)
			{
				res = "Избыточная масса тела (предожирение)";
			}
			else if (bmi <= 35)
			{
				res = "Ожирение первой степени";
			}
			else if (bmi <= 40)
			{
				res = "Ожирение второй степени";
			}
			else
			{
				res = "Ожирение третьей степени";
			}

			//Вывод в консоль:
			Helper.Line();
			Console.WriteLine($"Индекс массы тела: {bmi:##.00}\nЗаключение: {res}");
			//Если не норма - отправить на доп.расчеты
			if (!isNormal)
			{
				double diff = ChangeMass(w, h, bmi);
				Console.WriteLine("Для достижения нормы Вам необходимо {0} {1:F2} кг", diff > 0 ? "сбросить" : "набрать", Math.Abs(diff));
			}
			Helper.Line();
		}

		#endregion

		#region Вычисление разницы текущей массы и нормальной массы

		/// <summary>
		/// Функция подсчета массы, которую надо набрать (сбросить) до нормы
		/// </summary>
		/// <param name="weight">Текущая масса человека</param>
		/// <param name="height">Рост человека (не изменить)</param>
		/// <param name="bmi">Текущий индекс массы тела человека</param>
		/// <returns></returns>
		private static double ChangeMass(double weight, double height, double bmi)
		{
			double bmiNormal = bmi >= 25 ? 24.99 : 18.50;       //Находим ближайшее номальное значение Индекса Массы тела
			double mass = bmiNormal * height * height;          //Зная индекс, к оторому надо стремиться, и рост человека,
																//без труда находим какая при этом должна быть масса

			return weight - mass;                               //Вычитаем из текущей массы нормальную массу и возвращаем результат
		}

		#endregion

		#endregion

		#region Поиск количества хороших чисел (задача 6)

		/// <summary>
		/// Функция поиска "хороших" числе. Полумолчанию, поиск идет от 1 до 1 000 000.
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
				{
					count++;                        //Если да - у нас на одно "хорошее" число больше.
				}
			}
			DateTime endLong = DateTime.Now;        //останавливаем атймер

			//Выводим на печать полученные результаты:
			Console.WriteLine(
				$"Количество \"хороших\" чисел в диапазоне от {first} до {last}: {count}\n" +
				$"Общие временные затраты: {(endLong - startLong).TotalMilliseconds}");
		}

		#endregion

		#region Рекурсивные подсчеты между числами a и b (задача 7)

		/// <summary>
		/// Функция вывода на печать целых чисел от a до b
		/// </summary>
		/// <param name="a">Число, от которого начинаем выборку</param>
		/// <param name="b">Число, на котором выборка заканчивается</param>
		private static void RecursePrint(int a, int b)
		{
			if (a <= b)                     //Погружаемся в рекурсию  до тех пор, пока первый передаваемый аргумент не станет больше второго
			{
				Console.WriteLine(a);       //Пишем первое число из переданных в функцию
				RecursePrint(++a, b);       //Передаем в функцию аргументы: первый плюс один, и творйо без изменений
			}

		}

		/// <summary>
		/// Функция получения суммы целых чисел от a до b
		/// </summary>
		/// <param name="a">Число, от которого начинаем выборку</param>
		/// <param name="b">Число, на котором выборка заканчивается</param>
		/// <returns></returns>
		private static int RecurseSumm(int a, int b)
		{
			if (a < b)                              //Погружаемся в рекурсию  до тех пор, пока первый передаваемый аргумент не станет
													//больше или равным второму
			{
				return a + RecurseSumm(++a, b);     //Возвращаем сумму первого аргумента и результат рекурсивной функции
			}
			return b;                               //Когда первый аргумент достиг второго - возвращаем значение второго аргумента
		}

		#endregion

		#endregion
	}
}
