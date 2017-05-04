﻿using System;
using Helper;

namespace UnivariateArray
{
	class UnivariateArrayWork
	{
		static void Main(string[] args)
		{
			//Переменная пути к файлу
			string path = "test.vt";
			//Создаем объект - 5 элементов., перый - 1, с шагом 7
			UnivariateArray arr1 = new UnivariateArray(5, 1, 7);
			//Выводим объект на печать
			Console.WriteLine("Первый массив:\t{0}", arr1);
			//Сохраняем массив в файл
			arr1.SaveToFile(path);
			LogicHelper.Line();

			//Инвертируем массив
			arr1.Inverse();
			//Выводим инвертированный массив на печать
			Console.WriteLine("Инвертированный первый массив:\t{0}", arr1);
			LogicHelper.Line();

			//Создаем новый объект - из файла, в который ранее сохранили массив
			UnivariateArray arr2 = UnivariateArray.CreateFromFile(path);
			//Выводим на печать новый массив
			Console.WriteLine("Второй массив:\t{0}", arr2);
			//Выводим на печать сумму элементов массива
			Console.WriteLine("Сумма элементов массива:\t{0}", arr2.Sum);
			//Создаем множитель и умножаем каждый элемент массива на него
			int multi = 3;
			arr2.Multi(multi);
			//Выводим на печать умноженный массив
			Console.WriteLine("Результат умножения каждого элемента массива на {0}:\t{1}", multi, arr2);
			LogicHelper.Line();

			//Создаем новый объект - 5 элементов, каждый равен 10
			UnivariateArray arr3 = new UnivariateArray(5, 10);
			//Выводим на печать третий массив
			Console.WriteLine("Третий массив:\t{0}", arr3);
			//Выводим на печать количество максимальных объектов (при таком создании каждый элемент является максимальным)
			Console.WriteLine("Количество максимальных объектов в третьем массиве:\t{0}", arr3.MaxCount);

			LogicHelper.Pause();
		}
	}
}
