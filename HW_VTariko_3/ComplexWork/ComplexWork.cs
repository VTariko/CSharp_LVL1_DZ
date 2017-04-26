using System;
using Helper;

namespace ComplexWork
{
	class ComplexWork
	{
		static void Main(string[] args)
		{
			Complex com1 = new Complex(3, 4);
			Complex com2 = new Complex(1, 2);
			Console.WriteLine(com1);
			Console.WriteLine(com2);

			Console.WriteLine(com1.Plus(com2));
			Console.WriteLine(com1.Minus(com2));
			Console.WriteLine(com1.Multiply(com2));
			Console.WriteLine(com1.Divide(com2));

			LogicHelper.Pause();
		}
	}
}
