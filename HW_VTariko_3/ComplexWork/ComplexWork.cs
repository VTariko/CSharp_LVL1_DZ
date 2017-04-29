using System;
using Helper;

namespace ComplexWork
{
	//Домашняя работа C#-1, Урок 3
	//Выполнил: Вячеслав Тарико (VTariko)
	//
	//1.	а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.
	//Продемонстрировать работу структуры;
	//		б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить
	//работу класса;

	class ComplexWork
	{
		static void Main(string[] args)
		{
			//Создадим два комплексных числа для демонстрации работы:
			Complex com1 = new Complex(3, 4);
			Complex com2 = new Complex(1, 2);

			//Выводим их на печать (благодаря переопределенному методу ToString() мы получим приятный глазу результат)
			Console.WriteLine($"Первое комплексное число: {com1}");
			Console.WriteLine($"Второе комплексное число: {com2}");

			//Создаем шаблон сообщения для вывода на печать
			const string res = "Результат {0} комплексных чисел {1} и {2}:\t{3}";

			//Суммируем два комплексных числа:
			Console.WriteLine(res, "сложения", com1, com2, com1.Plus(com2));
			//Вычитаем два комплексных числа:
			Console.WriteLine(res, "вычитания", com1, com2, com1.Minus(com2));
			//Умножаем два комплексных числа:
			Console.WriteLine(res, "умножения", com1, com2, com1.Multiply(com2));
			//Делим два комплексных числа:
			Console.WriteLine(res, "деления", com1, com2, com1.Divide(com2));

			LogicHelper.Pause();
		}
	}
}
