using System;
using Helper;

namespace FractionsWork
{
	class FractionsWork
	{
		static void Main(string[] args)
		{
			Fraction fraction1 = new Fraction(4, 5);
			Fraction fraction2 = new Fraction(3, 2);
			
			Console.WriteLine(fraction1);
			Console.WriteLine(fraction2);

			Fraction fraction;
			const string res = "Результат {0} дробей {1} и {2}:\t{3}";


			fraction = fraction1 + fraction2;
			Console.WriteLine(res, "сложения", fraction1, fraction2, fraction);

			fraction = fraction1 - fraction2;
			Console.WriteLine(res, "вычитания", fraction1, fraction2, fraction);

			fraction = fraction1 * fraction2;
			Console.WriteLine(res, "умножения", fraction1, fraction2, fraction);

			fraction = fraction1 / fraction2;
			Console.WriteLine(res, "деления", fraction1, fraction2, fraction);

			LogicHelper.Pause();
		}
	}
}
