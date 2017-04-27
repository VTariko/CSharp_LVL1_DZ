using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FractionsWork
{
	using static Math;

	class Fraction
	{
		#region Свойства

		/// <summary>
		/// Числитель дроби
		/// </summary>
		public int Numerator { get; set; }

		/// <summary>
		/// Знаменатель дроби
		/// </summary>
		public int Denominator
		{
			get { return _denominator; }
			set
			{
				if (value != 0)
				{
					_denominator = value;
				}
				else
				{
					_denominator = 1;
				}
			}
		}

		#endregion

		#region Поля

		private int _denominator;

		#endregion

		#region Конструкторы

		/// <summary>
		/// Констурктор по умолчанию
		/// </summary>
		public Fraction()
		{
			Numerator = 1;
			Denominator = 1;
		}

		/// <summary>
		/// Конструктор с передаваемыми параметрами числителя и знаменателя
		/// </summary>
		/// <param name="numerator">Числитель</param>
		/// <param name="denominator">Знаменатель</param>
		public Fraction(int numerator, int denominator)
		{
			Numerator = numerator;
			Denominator = denominator;
		}

		#endregion

		#region Методы

		/// <summary>
		/// Переопределение оператора сложения
		/// </summary>
		/// <param name="f1">Первое слагаемое</param>
		/// <param name="f2">Второе слагаемое</param>
		/// <returns></returns>
		public static Fraction operator +(Fraction f1, Fraction f2)
		{
			int nok = Nok(f1.Denominator, f2.Denominator);
			int numenator1 = f1.Numerator * nok / f1.Denominator;
			int numenator2 = f2.Numerator * nok / f2.Denominator;

			return new Fraction
			{
				Numerator = numenator1 + numenator2,
				Denominator = nok
			};
		}

		/// <summary>
		/// Переопределение оператора разности
		/// </summary>
		/// <param name="f1">Уменьшаемое</param>
		/// <param name="f2">Вычитаемое</param>
		/// <returns></returns>
		public static Fraction operator -(Fraction f1, Fraction f2)
		{
			int nok = Nok(f1.Denominator, f2.Denominator);
			int numenator1 = f1.Numerator * nok / f1.Denominator;
			int numenator2 = f2.Numerator * nok / f2.Denominator;

			return new Fraction
			{
				Numerator = numenator1 - numenator2,
				Denominator = nok
			};
		}

		/// <summary>
		/// Переопределение оператора умножения
		/// </summary>
		/// <param name="f1">Множимое</param>
		/// <param name="f2">Множитель</param>
		/// <returns></returns>
		public static Fraction operator *(Fraction f1, Fraction f2)
		{
			Fraction fraction = new Fraction
			{
				Numerator = f1.Numerator * f2.Numerator,
				Denominator = f1.Denominator * f2.Denominator
			};
			int nod = Nod(fraction.Numerator, fraction.Denominator);
			fraction.Numerator /= nod;
			fraction.Denominator /= nod;

			return fraction;
		}

		/// <summary>
		/// Переопределение оператора деления
		/// </summary>
		/// <param name="f1">Делимое</param>
		/// <param name="f2">Делитель</param>
		/// <returns></returns>
		public static Fraction operator /(Fraction f1, Fraction f2)
		{
			Fraction fraction = new Fraction
			{
				Numerator = f1.Numerator * f2.Denominator,
				Denominator = f1.Denominator * f2.Numerator
			};
			int nod = Nod(fraction.Numerator, fraction.Denominator);
			fraction.Numerator /= nod;
			fraction.Denominator /= nod;

			return fraction;
		}

		/// <summary>
		/// Наименьшее общее кратное
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		private static int Nok(int a, int b)
		{
			return Abs(a * b) / Nod(a, b);
		}

		/// <summary>
		/// Наибольший общий делитель
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		private static int Nod(int a, int b)
		{
			while (b != 0)
			{
				int t = a % b;
				a = b;
				b = t;
			}
			return a;
		}

		/// <summary>
		/// Поиск знака дроби
		/// </summary>
		/// <returns></returns>
		private char Sign()
		{
			return (Numerator >= 0 && Denominator > 0) || (Numerator <= 0 && Denominator < 0) ? '\0' : '-';
		}

		/// <summary>
		/// Переопределение метода ToString()
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			//Если знаменатель равен единице - не отображаем его
			string denom = Denominator != 1 ? string.Format($"/{Denominator}") : "";
			//Если числитель равен нулю - вся дробь равна нулю
			return Numerator == 0 ? "0" : string.Format("{0}{1}{2}", Sign(), Abs(Numerator), denom);
		}

		#endregion
	}
}
