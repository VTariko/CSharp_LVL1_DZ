using System;

namespace Console_App_1
{
	using static Math;
	class Program
	{
		//Домашняя работа C#-1, Урок 1
		//Выполнил: Вячеслав Тарико (VTariko)
		//
		// 1. Написать программу “Анкета”. Последовательно задаются вопросы (имя, фамилия, возраст,
		// рост, вес). В результате вся информация выводится в одну строчку.
		//		а) используя склеивание;
		//		б) используя форматированный вывод.
		// 2. Ввести вес и рост человека. Расчитать и вывести индекс массы тела(ИМТ) по формуле
		// I=m/(h*h); где mмасса тела в килограммах, h рост в метрах
		//		*Интерпритировать показания ИМТ .
		// 3.	а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1
		// и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2x1,2)+ Math.Pow(y2y1,2).
		// Вывести результат используя спецификатор формата .2f (с двумя знаками после запятой);
		//		б) *Выполните предыдущее задание оформив вычисления расстояния между точками в виде
		// метода;
		// 4. Написать программу обмена значениями двух переменных
		//		а) с использованием третьей переменной;
		//		б) *без использования третьей переменной.
		// 5.	а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
		//		б) *Сделайте задание, только вывод организуйте в центре экрана
		//		в) **Сделайте задание б с использованием собственных методов (например, Print(string ms, int x,int y)
		// 6. Создайте класс с методами, которые могут пригодиться в вашей учебе(Print, Pause).

		/// <summary>
		/// Класс человека (персоны)
		/// </summary>
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
			/// Город проживания
			/// </summary>
			public string City { get; set; }

			
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

		/// <summary>
		/// Класс точки
		/// </summary>
		class Point
		{
			/// <summary>
			/// Координата точки по Иксу
			/// </summary>
			public int X { get; set; }

			/// <summary>
			/// Координата точки по Игреку
			/// </summary>
			public int Y { get; set; }

			/// <summary>
			/// Констуктор точки
			/// </summary>
			/// <param name="x">Координата Икс</param>
			/// <param name="y">Координата Игрек</param>
			public Point(int x, int y)
			{
				X = x;
				Y = y;
			}

			/// <summary>
			/// Метод поиска расстояния между текущей точкой и выбранной
			/// </summary>
			/// <param name="aPoint">выбранная точка</param>
			/// <returns>Расстояние</returns>
			public double DistanceTo(Point aPoint)
			{
				double distance = Sqrt(Pow(aPoint.X - this.X, 2) + Pow(aPoint.Y - this.Y, 2));
				Console.WriteLine($"Расстояние от точки ({X};{Y}) до точки ({aPoint.X};{aPoint.Y}) равняется {distance:F2}");
				return distance;
			}
		}


		static void Main(string[] args)
		{
			#region Анкета персоны и индекс массы тела

			//Создание персоны через заполнение анкеты
			Person me = Profile();
			//Вывод данных
			me.InfoGlue();
			me.InfoFormat();

			//Получение индекса массы тела (на примере созданной персоны, но можно использовать любые данные)
			BodyMassIndex(me.Weight, me.Height);

			#endregion

			#region Работа с точками

			//Создаем три точки и считаем расстояние между ними
			Point p1 = new Point(1, 1);
			Point p2 = new Point(2, 2);
			Point p3 = new Point(5, 7);

			Console.WriteLine(new string('-', 40));
			p1.DistanceTo(p2);
			p2.DistanceTo(p1);  //Два первых результата должны быть одинаковыми
			p1.DistanceTo(p3);
			p2.DistanceTo(p3);
			Console.WriteLine(new string('-', 40));

			#endregion

			#region Обмен значениями

			Console.WriteLine(new string('-', 40));
			Console.WriteLine("Обмен значениями с использованием временной переменной");
			int x1 = 2;
			int y1 = 4;
			Console.WriteLine($"До подмены. X = {x1}, Y = {y1}");
			ChangeWithTemp(ref x1, ref y1);     //с использованием временной переменной
			Console.WriteLine($"После подмены. X = {x1}, Y = {y1}");
			Console.WriteLine(new string('-', 40));
			Console.WriteLine(new string('-', 40));
			Console.WriteLine("Обмен значениями без использования временной переменной (первый способ - только числа)");
			int x2 = 2;
			int y2 = 4;
			Console.WriteLine($"До подмены. X = {x2}, Y = {y2}");
			ChangeWithoutTemp_1(ref x2, ref y2);  //без использования временной переменной (подходит только для чисел)
			Console.WriteLine($"После подмены. X = {x2}, Y = {y2}");
			Console.WriteLine(new string('-', 40));
			Console.WriteLine(new string('-', 40));
			Console.WriteLine("Обмен значениями без использования временной переменной (второй способ - любые типы)");
			int x3 = 2;
			int y3 = 4;
			Console.WriteLine($"До подмены. X = {x3}, Y = {y3}");
			ChangeWithoutTemp_2(ref x3, ref y3);  //без использования временной переменной (подходит для любых типов данных)
			Console.WriteLine($"После подмены. X = {x3}, Y = {y3}");
			Console.WriteLine(new string('-', 40));

			#endregion

			Console.ReadKey();  //Ожидаем ввод перед очисткой экрана
			Console.Clear();    //Очистка консоли

			#region Вывод посередине

			me.City = "Moscow"; //Дополним созданную персону

			string info = string.Format("{0} {1}, {2}", me.FirstName, me.LastName, me.City); // создадим строку
			
			int w = Console.WindowWidth;
			int h = Console.WindowHeight;
			int x = (w - info.Length)/2;
			int y = (h - 1)/2;
			PrintInfo(info, x, y);

			#endregion

			Console.ReadKey();
		}

		#region Методы

		#region Метод "Анкета"

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

		#endregion

		#region Метод "Индекс массы тела"

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

		#endregion

		#region Обмен переменными

		/// <summary>
		/// Метод обмена значениями с использованием временной переменной
		/// </summary>
		/// <param name="a">Первый параметр</param>
		/// <param name="b">Второй параметр</param>
		static void ChangeWithTemp(ref int a, ref int b)
		{
			int t = a;
			a = b;
			b = t;
		}

		/// <summary>
		/// Метод обмена значениями без использования временной переменной (подходит только для чисел)
		/// </summary>
		/// <param name="a">Первый параметр</param>
		/// <param name="b">Второй параметр</param>
		static void ChangeWithoutTemp_1(ref int a, ref int b)
		{
			a = a + b;
			b = a - b;
			a = a - b;
		}

		/// <summary>
		/// Метод обмена значениями без использования временной переменной (подходит для любых типов данных)
		/// </summary>
		/// <param name="a">Первый параметр</param>
		/// <param name="b">Второй параметр</param>
		static void ChangeWithoutTemp_2(ref int a, ref int b)
		{
							//Для примера, пусть изначально		 a = 110, b = 101
			a = a ^ b;		//a = a ^ b = 110 ^ 101 = 011; Тогда a = 011, b = 101
			b = a ^ b;		//b = a ^ b = 011 ^ 101 = 110; Тогда a = 011, b = 110
			a = a ^ b;		//a = a ^ b = 011 ^ 110 = 101; Тогда a = 101, b = 110 - произошла подмена значений
		}

		#endregion

		#region Метод вывода на печать в центре

		/// <summary>
		/// Метод вывода на печать в центре консоли
		/// </summary>
		/// <param name="info">Строка для вывода</param>
		/// <param name="x">Положение для печати по иксу</param>
		/// <param name="y"></param>
		static void PrintInfo(string info, int x, int y)
		{
			Console.SetCursorPosition(x, y);
			Console.WriteLine(info);
		}

		#endregion

		#endregion

	}
}