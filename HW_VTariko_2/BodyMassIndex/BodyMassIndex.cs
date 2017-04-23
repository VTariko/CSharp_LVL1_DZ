using System;
using Helper;

namespace BodyMassIndex
{
	//Домашняя работа C#-1, Урок 1
	//Выполнил: Вячеслав Тарико (VTariko)
	//
	//Внимание! Решал задачи 5, 6 и 7.
	//
	//5.	а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс
	//массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;
	//		б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.


	class BodyMassIndex
	{
		static void Main(string[] args)
		{
			MassHeight();
			LogicHelper.Pause();
		}

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
				Console.Write("Введите свой рост, м: ");
			} while (!double.TryParse(Console.ReadLine(), out height) && height <= 0);

			//Проверка массы на валидность
			do
			{
				Console.Write("Введите свой вес, кг: ");
			} while (!double.TryParse(Console.ReadLine(), out weight) && weight <= 0);

			BodyIndex(weight, height);              //Передаем полученные массу и рост для вычисления Индекса массы тела
		}

		#endregion

		#region Метод вычесления индекса массы тела

		/// <summary>
		/// Функция вычисления индекса массы тела
		/// </summary>
		/// <param name="w">Масса тела испытуемого</param>
		/// <param name="h">Рост тела испытуемого</param>
		static void BodyIndex(double w, double h)
		{
			bool isNormal = false;                                  //Заводим переменную ,которая скажет нам,
																	//в норме ли наш пациент и если нет - отправит результаты на расчет
			double bmi = w / (h * h);                               //Подсчет индекса массы тела
			string res;                                             //Переменная для интерпритации результатов
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
			LogicHelper.Line();
			Console.WriteLine($"Индекс массы тела: {bmi:##.00}\nЗаключение: {res}");
			//Если не норма - отправить на доп.расчеты
			if (!isNormal)
			{
				double diff = ChangeMass(w, h, bmi);
				Console.WriteLine("Для достижения нормы Вам необходимо {0} {1:F2} кг", diff > 0 ? "сбросить" : "набрать", Math.Abs(diff));
			}
			LogicHelper.Line();
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
	}
}
