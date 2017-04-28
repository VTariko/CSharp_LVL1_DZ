using System;
using Helper;

namespace FractionsWork
{
	class FractionsWork
	{
		static void Main(string[] args)
		{
			//Создадим две дроби дял демонстрации работы:
			Fraction fraction1 = new Fraction(4, 5);
			Fraction fraction2 = new Fraction(3, 2);
			
			//Выводим их на печать (благодаря переопределенному методу ToString() мы получим приятный глазу результат)
			Console.WriteLine($"Первая дробь: {fraction1}");
			Console.WriteLine($"Вторая дробь: {fraction2}");

			//Создаем объект типа дроби, который будет принимать значения результатов математических операций
			Fraction fraction;
			//Создаем шаблон сообщения для вывода на печать
			const string res = "Результат {0} дробей {1} и {2}:\t{3}";

			//Суммируем две дроби:
			fraction = fraction1 + fraction2;
			Console.WriteLine(res, "сложения", fraction1, fraction2, fraction);
			//Вычитаем две дроби:
			fraction = fraction1 - fraction2;
			Console.WriteLine(res, "вычитания", fraction1, fraction2, fraction);
			//Умножаем две дроби:
			fraction = fraction1 * fraction2;
			Console.WriteLine(res, "умножения", fraction1, fraction2, fraction);
			//Делим две дроби:
			fraction = fraction1 / fraction2;
			Console.WriteLine(res, "деления", fraction1, fraction2, fraction);

			LogicHelper.Pause();
		}
	}
}
