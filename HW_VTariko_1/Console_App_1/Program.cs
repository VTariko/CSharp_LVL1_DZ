using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_1
{
	class Program
	{
		class Person
		{
			/// <summary>
			/// Имя
			/// </summary>
			public string FirstName { get; }

			/// <summary>
			/// Фамилия
			/// </summary>
			public string LastName { get; }

			/// <summary>
			/// Возраст, лет
			/// </summary>
			public byte Age { get; }

			/// <summary>
			/// Рост, м
			/// </summary>
			public float Height { get; }

			/// <summary>
			/// Вес, кг
			/// </summary>
			public float Weight { get; }

			
			/// <summary>
			/// Констурктор персоны
			/// </summary>
			/// <param name="firstName">Имя</param>
			/// <param name="lastName">Фамилия</param>
			/// <param name="age">Возраст, лет</param>
			/// <param name="height">Рост, м</param>
			/// <param name="weight">Вес, кг</param>
			public Person(string firstName, string lastName, byte age, float height, float weight)
			{
				FirstName = firstName;
				LastName = lastName;
				Age = age;
				Height = height;
				Weight = weight;
			}

			/// <summary>
			/// Вывод информации методом "склейки"
			/// </summary>
			public void InfoGlue()
			{
				Console.WriteLine(new string('-', 40));
				Console.WriteLine("Вывод информации методом \"склейки\"");
				Console.WriteLine();
				Console.WriteLine("Имя:\t\t" + FirstName + "\nФамилия:\t" + LastName + "\nВозраст:\t" + Age + "\nРост:\t\t" + Height +
				                  "\nВес:\t\t" + Weight);
				Console.WriteLine(new string('-', 40));
			}

			/// <summary>
			/// Вывод информации методом форматирования
			/// </summary>
			public void InfoFormat()
			{
				Console.WriteLine(new string('-', 40));
				Console.WriteLine("Вывод информации методом форматирования");
				Console.WriteLine();
				Console.WriteLine(
					$"{"Имя",15}: {FirstName,20}\n{"Фамилия",15}: {LastName,20}\n{"Возраст",15}: {Age,20}\n{"Рост",15}: {Height,20}\n{"Вес",15}: {Weight,20}");
				Console.WriteLine(new string('-', 40));
			}
		}


		static void Main(string[] args)
		{
			Person me = Profile();
			me.InfoGlue();
			me.InfoFormat();
			BodyMassIndex(me.Weight, me.Height);
			Console.ReadKey();
		}

		/// <summary>
		/// Функция заполнения анкеты
		/// </summary>
		/// <returns>Созданный профиль пользователя</returns>
		static Person Profile()
		{
			byte age;
			float weight, height;

			Console.Write("Введите свое имя:");
			string firstName = Console.ReadLine();
			Console.Write("Введите свою фамилию:");
			string lastName = Console.ReadLine();

			//Проверка возраста на валидность 
			do
			{
				Console.Write("Введите свой возраст:");
			} while (!byte.TryParse(Console.ReadLine(), out age) && age <=0);

			//Проверка роста на валидность
			do
			{
				Console.Write("Введите свой рост, м:");
			} while (!float.TryParse(Console.ReadLine(), out height) && height <= 0);

			//Проверка массы на валидность
			do
			{
				Console.Write("Введите свой вес, кг:");
			} while (!float.TryParse(Console.ReadLine(), out weight) && weight <= 0);

			//Вызов конструктора класса пользователя
			Person person = new Person(firstName, lastName, age, height, weight);
			return person;
		}

		/// <summary>
		/// Функция вычисления индекса массы тела
		/// </summary>
		/// <param name="w">Масса тела испытуемого</param>
		/// <param name="h">Рост тела испытуемого</param>
		static void BodyMassIndex(float w, float h)
		{
			//Подсчет индекса массы тела
			float bmi = w/(h*h);
			
			//Интерпритация результатов
			string res;
			if (bmi <= 16)
			{
				res = "Выраженный дефицит массы тела";
			} else if (bmi <= 18.5)
			{
				res = "Недостаточная (дефицит) масса тела";
			} else if (bmi < 25)
			{
				res = "Норма";
			} else if (bmi <= 35)
			{
				res = "Избыточная масса тела (предожирение)";
			} else if (bmi <= 35)
			{
				res = "Ожирение первой степени";
			} else if (bmi <= 40)
			{
				res = "Ожирение второй степени";
			}
			else
			{
				res = "Ожирение третьей степени";
			}

			//Вывод в консоль:
			Console.WriteLine(new string('-', 40));
			Console.WriteLine($"Индекс массы тела: {bmi:##.00}\nЗаключение: {res}");
			Console.WriteLine(new string('-', 40));
		}
	}
}
