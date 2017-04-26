using System;

namespace ComplexWork
{
	using static Math;
	class Complex
	{
		#region Свойства

		/// <summary>
		/// Действительная часть комплексного числа
		/// </summary>
		public double Re { get; set; }

		/// <summary>
		/// Мнимая часть комплексного числа
		/// </summary>
		public double Im { get; set; }

		#endregion

		#region Конструкторы

		public Complex()
		{
			Re = 0;
			Im = 0;
		}

		public Complex(double re, double im)
		{
			Re = re;
			Im = im;
		}

		#endregion

		#region Методы

		/// <summary>
		/// Сложение комплексных чисел
		/// </summary>
		/// <param name="aComplex">Число, с которым надо сложить данное комплексное число</param>
		/// <returns>Комплексное число, результат сложения</returns>
		public Complex Plus(Complex aComplex)
		{
			// z1 + z2 = (a + b*i) + (c + d*i) = (a + c) + (b + d)*i
			return new Complex(Re + aComplex.Re, Im + aComplex.Im);
		}

		/// <summary>
		/// Вычитание комплексных чисел
		/// </summary>
		/// <param name="aComplex">Число, которое надо вычесть из данного комплексного числа</param>
		/// <returns>Комплексное число, результат вычитания</returns>
		public Complex Minus(Complex aComplex)
		{
			// z1 - z2 = (a + b*i) - (c + d*i) = (a - c) + (b - d)*i
			return new Complex(Re - aComplex.Re, Im - aComplex.Im);
		}

		/// <summary>
		/// Деление комплексных чисел
		/// </summary>
		/// <param name="aComplex">Число, на которое надо разделить данное комплексное число</param>
		/// <returns>Комплексное число, результат деления</returns>
		public Complex Divide(Complex aComplex)
		{
			// z1/z2 = (a + b*i)/(c + d*i) = ((a*c + b*d)/(c*c + d*d)) + ((b*c - a*d)/(c*c + d*d))*i
			Complex complex = new Complex
			{
				Re = ((Re*aComplex.Re + Im*aComplex.Im)/(aComplex.Re*aComplex.Re + aComplex.Im*aComplex.Im)),
				Im = ((Im*aComplex.Re - Re*aComplex.Im)/(aComplex.Re*aComplex.Re + aComplex.Im*aComplex.Im))
			};
			return complex;
		}

		/// <summary>
		/// Умножение комплексных чисел
		/// </summary>
		/// <param name="aComplex">Число, на которое надо умножить данное комплексное число</param>
		/// <returns>Комплексное число, результат умножения</returns>
		public Complex Multiply(Complex aComplex)
		{
			// z1*z2 = (a + b*i)*(c + d*i) = (a*c - b*d) + (a*d + b*c)*i
			Complex complex = new Complex
			{
				Re = Re * aComplex.Re - Im * aComplex.Im,
				Im = Re * aComplex.Im + Im * aComplex.Re
			};
			return complex;
		}

		/// <summary>
		/// Приведение комплексного числа к строке - переопределение
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("{0} {1} {2}i", Round(Re, 2),
				Im > 0 ? "+" : "-",
				Abs(Im - 1) > 0.01 ? Round(Abs(Im), 2).ToString() : "");
		}

		#endregion
	}
}
