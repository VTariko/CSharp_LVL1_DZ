using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FractionsWork
{
	class Fraction
	{
		/// <summary>
		/// Числитель дроби
		/// </summary>
		public int Numerator { get; set; }

		/// <summary>
		/// Знаменатель дроби
		/// </summary>
		public int Denominator
		{
			get
			{
				return denominator;
			}
			set
			{
				if (value != 0)
				{
					denominator = value;
				}
			}
		}

		private int numenator;
		private int denominator;

		public Fraction(int numenator, int denominator)
		{
			this.numenator = numenator;
			if (denominator != 0)
			{
				this.denominator = denominator;
			}
			else
			{
				
			}
			
		}
	}
}
